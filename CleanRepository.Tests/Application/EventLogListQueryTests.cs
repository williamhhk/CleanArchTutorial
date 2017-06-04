using Application.EventLog;
using Application.Interfaces.Persistence;
using Autofac;
using Autofac.Features.Variance;
using AutoMoq;
using Domain.Customers;
using MediatR;
using NUnit.Framework;
using Persistence.Shared.Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CleanRepository.Tests.Application
{
    [TestFixture]
    public class EventLogListQueryTests
    {
        private AutoMoqer _mocker;
        private IContainer Container;
        [SetUp]
        public void SetUp()
        {
            //Autofac Configuration
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.Load("Domain")).AsImplementedInterfaces(); // via assembly scan
            builder.RegisterAssemblyTypes(Assembly.Load("Application")).AsImplementedInterfaces(); // via assembly scan
            builder.RegisterAssemblyTypes(Assembly.Load("Common")).AsImplementedInterfaces(); // via assembly scan
            // NOTE : 'connectionStr' match parameter name in DemoDbConnectionFactory
            builder.RegisterType<DemoDbConnectionFactory>().As<IDemoDbConnectionFactory>().WithParameter("connectionStr", "Data Source=WILLIAM-AZ;Initial Catalog=EventsLog;Integrated Security=True").SingleInstance();
            // MediatR
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

            Container = builder.Build();

        }

        [Test]
        public async Task EventLogListQueryTests_Dapper_Inline_Query_No_Error()
        {
            //Assign
            var mediator = Container.Resolve<IMediator>();

            // Act
            var response = await mediator.Send(new EventLogQuery.Query());

            // Assert
            Assert.IsTrue(response.Count > 0);

        }
    }
}
