using System.Web.Http;
using WebApi.App_Start;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            UnityConfig.RegisterComponents(new DALOption(null));
        }
    }
}
