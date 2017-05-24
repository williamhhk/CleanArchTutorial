using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries;
using Application.Interfaces.Persistence;
using Autofac;
using Autofac.Integration.WebApi;
using Domain.Customers;
using Domain.Employees;
using MediatR;
using Persistence.Customers;
using Persistence.Employees;
using Persistence.Memory.Shared;
using Persistence.Shared.Dapper;
using Persistence.Shared.EntityFramework;
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
            builder.RegisterType(typeof(GetEmployeesListQuery)).As(typeof(IGetEmployeesListQuery)).InstancePerRequest();

            //  Using Stubdata
            //builder.RegisterType<StubDataCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            //builder.RegisterType<MemoryRepository<Customer>>().As<MemoryRepository<Customer>>().SingleInstance();


            // Using Dapper
            //builder.RegisterType<DapperCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            //builder.RegisterType<DapperRepository<Customer>>().As<IRepository<Customer>>().SingleInstance();
            //builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().SingleInstance();


            // Using EF
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<Repository<Customer>>().As<IRepository<Customer>>().SingleInstance();
            //builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();

            builder.RegisterType<EmployeeRespository>().As<IEmployeeRepository>().SingleInstance();
            builder.RegisterType<Repository<Employee>>().As<IRepository<Employee>>().SingleInstance();
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().SingleInstance();

            // MediatR
            builder.RegisterType<Mediator>().As<IMediator>().SingleInstance();
            // Where the event handler is located.  
            builder.RegisterAssemblyTypes(Assembly.Load("Domain"))
                .Where(t => t.GetInterfaces().Any(i => !t.IsAbstract && i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IRequestHandler<CustomerCreated>))));




            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
