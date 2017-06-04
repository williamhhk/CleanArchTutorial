using Common;
using Service.CustomHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var config1 = new CredentialsManager();
            var domain = config1.Domain;


            // Web API configuration and services
            // Custom Message Handler, e.g. authenticate or checking before proceeding to next step in the pipeline.
            //config.MessageHandlers.Add(new MessageHandler());

            //  Replace default with custom Exception Handler.
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
