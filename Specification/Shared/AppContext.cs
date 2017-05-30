using Application.Customers.Queries.GetCustomerList;
using Application.Interfaces.Persistence;
using Autofac;
using Autofac.Core;
using AutoMoq;
using Domain.Customers;
using Persistence.Customers;
using Persistence.Memory.Shared;
using Persistence.Shared.EntityFramework;
using System;
using System.Reflection;

namespace Specification.Shared
{

    public class AppContext
    {
        public AutoMoqer Mocker;
        public IDatabaseContext DatabaseContext;
        public IContainer Container;

        public AppContext()
        {
            SetUpAutoMocker();
            SetUpMockDatabase();
            SetUpIocContainer();
        }

        private void SetUpAutoMocker()
        {
            Mocker = new AutoMoqer();
        }

        public void SetUpMockDatabase()
        {
            var mockDatabase = Mocker.GetMock<IDatabaseContext>();

            var intitializer = new DatabaseInitializer(mockDatabase);

            intitializer.Seed();

            DatabaseContext = mockDatabase.Object;
        }


        private void SetUpIocContainer()
        {
            ////Autofac Configuration
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(GetCustomersListQuery)).As(typeof(IGetCustomersListQuery)).SingleInstance();
            builder.RegisterType<Repository<Customer>>().As<IRepository<Customer>>();
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>();

            builder.RegisterType<StubDataCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<MemoryRepository<Customer>>().As<MemoryRepository<Customer>>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.Load("Specification")).AsSelf(); // via assembly scan
            Container = builder.Build();
        }
    }
}
