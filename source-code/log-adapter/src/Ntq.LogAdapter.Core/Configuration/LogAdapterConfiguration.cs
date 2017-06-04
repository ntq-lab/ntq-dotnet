using System;
using System.Configuration;
using System.IO;

namespace Ntq.LogAdapter.Core.Configuration
{
    public sealed class LogAdapterConfiguration : ConfigurationSection
    {
        private static readonly string ConfigFileName = "LogAdapter.config";
        private static readonly string ConfigSectionName = "LogAdapterConfiguration";

        #region Load configuration from App.config/Web.config/LogAdapter.config file

        private static readonly Lazy<LogAdapterConfiguration> _defaultConfigurationHolder =
                                    new Lazy<LogAdapterConfiguration>(() => GetLogAdapterConfiguration());
        /// <summary>
        /// Default diff configuration values
        /// </summary>
        public static LogAdapterConfiguration Default { get { return _defaultConfigurationHolder.Value; } }


        private static LogAdapterConfiguration GetLogAdapterConfiguration()
        {
            // Firstly: try get from application config file
            LogAdapterConfiguration diffConfig = ConfigurationManager.GetSection(ConfigSectionName) as LogAdapterConfiguration;
            if (diffConfig != null)
                return diffConfig;

            // Second: try get from LogAdapter.config file in application folder
            System.Configuration.Configuration configuration = LoadConfiguration();
            if (configuration != null)
                diffConfig = configuration.GetSection(ConfigSectionName) as LogAdapterConfiguration;

            return diffConfig ?? new LogAdapterConfiguration();
        }

        private static System.Configuration.Configuration LoadConfiguration()
        {
            string assemblyPath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            string configFile = Path.Combine(assemblyPath, ConfigFileName);
            if (!File.Exists(configFile))
                return null;

            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap() { ExeConfigFilename = configFile };
            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }
        #endregion

        [ConfigurationProperty("assembly", IsRequired = true)]
        public string Assembly
        {
            get { return (string)this["assembly"]; }
            set { this["assembly"] = value; }
        }

        [ConfigurationProperty("adapterClass", IsRequired = true)]
        public string AdapterClass
        {
            get { return (string)this["adapterClass"]; }
            set { this["adapterClass"] = value; }
        }

        [ConfigurationProperty("throwException", DefaultValue = false, IsRequired = false)]
        public bool ThrowException
        {
            get { return (bool)this["throwException"]; }
            set { this["throwException"] = value; }
        }

        public LogAdapterConfiguration()
        {
            this.ThrowException = false;
        }
    }
}
