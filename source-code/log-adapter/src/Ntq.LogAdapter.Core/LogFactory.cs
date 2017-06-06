using System;
using System.IO;
using System.Reflection;
using Ntq.LogAdapter.Core.Configuration;

namespace Ntq.LogAdapter.Core
{
    public class LogFactory
    {
        private static readonly Type AdapterBaseType = typeof(LogAdapterBase);
        private static readonly LogAdapterConfiguration LogAdapterConfig = LogAdapterConfiguration.Default;
        public static readonly LogFactory Default = new LogFactory();

        private readonly LogAdapterConfiguration _logAdapterConfiguration;

        public LogFactory()
        {
            this._logAdapterConfiguration = LogAdapterConfiguration.Default;
        }

        public LogFactory(LogAdapterConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            this._logAdapterConfiguration = config;
        }

        public virtual ILog GetLogger()
        {
            try
            {
                return CreateLogger();
            }
            catch (Exception)
            {
                if (LogAdapterConfig.ThrowException)
                    throw;
                return new DebugConsoleLogger();
            }
        }

        public virtual ILog GetLogger(string name)
        {
            try
            {
                return CreateLogger(name);
            }
            catch (Exception)
            {
                if (LogAdapterConfig.ThrowException)
                    throw;
                return new DebugConsoleLogger(name);
            }
        }

        private ILog CreateLogger(params object[] args)
        {
            string assembly = LogAdapterConfig.Assembly;
            string adapterName = LogAdapterConfig.AdapterClass;

            Type adapterType = LoadAdapterType(assembly, adapterName);
            if (!AdapterBaseType.IsAssignableFrom(adapterType))
                return null;
            return Activator.CreateInstance(adapterType, args) as ILog;

        }

        private Type LoadAdapterType(string assemblyName, string className)
        {
            string assemblyDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string assemblyPath = Path.Combine(assemblyDir, assemblyName);
            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException("Not found assembly which specified at " + assemblyPath, "assemblyName");
            }

            // TODO: Handle exception!!!
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Type type = assembly.GetType(className, false);
            if (!AdapterBaseType.IsAssignableFrom(type))
            {
                return null;
            }
            return type;
        }

        private ILog CreateDummyLogger(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new DebugConsoleLogger();
            else
                return new DebugConsoleLogger(name);
        }
    }
}
