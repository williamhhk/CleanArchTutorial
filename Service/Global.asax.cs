using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries;
using Application.Interfaces.Persistence;
using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using AutofacSerilogIntegration;
using Domain.Customers;
using Domain.Employees;
using MediatR;
using Persistence.Customers;
using Persistence.Employees;
using Persistence.Memory.Shared;
using Persistence.Shared.Dapper;
using Persistence.Shared.EntityFramework;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;


namespace Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Serilog Initialization
            var connectionString = @"Data Source=WILLIAM-AZ;Initial Catalog=EventsLog;Integrated Security=True";  // or the name of a connection string in your .config file
            var tableName = "Logs";
            var columnOptions = new ColumnOptions();  // optional

            columnOptions.Store.Add(StandardColumn.LogEvent);
            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOptions)
                //                .WriteTo.Console()
                .CreateLogger();


            //Autofac Configuration
            var builder = new ContainerBuilder();

            //  Register serilog using  Install-Package AutofacSerilogIntegration

            builder.RegisterLogger();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType(typeof(GetCustomersListQuery)).As(typeof(IGetCustomersListQuery)).SingleInstance();
            builder.RegisterType(typeof(GetEmployeesListQuery)).As(typeof(IGetEmployeesListQuery)).SingleInstance();


            // Use one of the following repository

            //  Using Stubdata
            builder.RegisterType<StubDataCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<MemoryRepository<Customer>>().As<MemoryRepository<Customer>>().SingleInstance();


            // Using Dapper
            //builder.RegisterType<DapperCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            //builder.RegisterType<DapperRepository<Customer>>().As<IRepository<Customer>>().SingleInstance();
            //builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().SingleInstance();


            // Using EF
            //builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            //builder.RegisterType<Repository<Customer>>().As<IRepository<Customer>>().SingleInstance();
            ////builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();

            //builder.RegisterType<EmployeeRespository>().As<IEmployeeRepository>().SingleInstance();
            //builder.RegisterType<Repository<Employee>>().As<IRepository<Employee>>().SingleInstance();
            //builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();

            //// MediatR
            //builder.RegisterType<Mediator>().As<IMediator>().SingleInstance();
            //// Where the event handler is located.  
            //builder.RegisterAssemblyTypes(Assembly.Load("Domain"))
            //    .Where(t => t.GetInterfaces().Any(i => !t.IsAbstract && i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IRequestHandler<CustomerCreated>))));


            // MediatR
            builder
            .RegisterSource(new ContravariantRegistrationSource());

            // mediator itself
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            // request handlers
            builder
              .Register<SingleInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();

            // notification handlers
            builder
              .Register<MultiInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();

            // finally register our custom code (individually, or via assembly scanning)
            // - requests & handlers as transient, i.e. InstancePerDependency()
            // - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
            // - behaviors as transient, i.e. InstancePerDependency()
            builder.RegisterAssemblyTypes(Assembly.Load("Domain")).AsImplementedInterfaces(); // via assembly scan
            builder.RegisterAssemblyTypes(Assembly.Load("Application")).AsImplementedInterfaces(); // via assembly scan
                                                                                              //
            var container = builder.Build();

            //  Set resolver for anti-IOC later user
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            



        }
    }
}
