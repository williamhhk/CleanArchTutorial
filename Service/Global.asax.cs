using Application.Customers.Queries.GetCustomerList;
using Application.Interfaces.Persistence;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Autofac Configuration
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType(typeof(GetCustomersListQuery)).As(typeof(IGetCustomersListQuery)).InstancePerRequest();
     //       builder.RegisterType(typeof(GetCustomersListQuery)).As(typeof(ICustomerRepository)).InstancePerRequest();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
