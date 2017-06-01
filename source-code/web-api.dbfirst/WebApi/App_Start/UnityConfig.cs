using System.Web.Http;
using DAL.Repository;
using EFDBFirst;
using Interface.DAL;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace WebApi.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(DALOption dalOption)
        {
            var container = new UnityContainer();
            container.RegisterInstance<IDALOption>(dalOption);
            container.RegisterInstance<IContext>(new DBEntities());


            container.RegisterType<IUserRepository<User>, UserRepository<User>>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}