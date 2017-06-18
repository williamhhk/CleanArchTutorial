using DnsClient;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Service.DnsClient.App_Start
{
    public class SimpleInjectorBootstrapper
    {
        public static void Initalize()
        {

            // 1. Create a new Simple Injector container
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // 2. Configure the container (register)
            // See below for more configuration examples
            container.Register<ILookupClient>(() => new LookupClient(), Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Store the container for use by the application
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

    }
}