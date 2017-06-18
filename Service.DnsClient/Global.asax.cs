using Service.DnsClient.App_Start;
using System.Web.Http;

namespace Service.DnsClient
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SimpleInjectorBootstrapper.Initalize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
