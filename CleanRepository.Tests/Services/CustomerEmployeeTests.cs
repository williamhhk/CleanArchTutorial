using Application.Customers.Queries.GetCustomerList;
using AutoMoq;
using Domain.Customers;
using MediatR;
using Moq;
using NUnit.Framework;
using Service.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace CleanRepository.Tests.Services
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private CustomersController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();
        }

        [Test]
        public void CustomersControllerTests_ConstructorShouldReturnList_No_Error()
        {
            var customers  = new List<CustomerModel>() { new CustomerModel() { Id = 1, Name = "William" } };

            var mediator = new Mock<IMediator>();
            var tcs = new TaskCompletionSource<List<CustomerModel>>();
            tcs.SetResult(customers);
            mediator.Setup(m => m.Send(It.IsAny<GetCustomersListQuery1>(), It.IsAny<CancellationToken>())).Returns(tcs.Task);

            // Act
            var controller = new CustomersController(mediator.Object);
            var results = controller.Get() as System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<CustomerModel>>;

            // Assert 
            Assert.AreEqual(results.Content.FirstOrDefault(), customers.FirstOrDefault());

            //var results = controller.Get() as System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.IEnumerable<EmployeeModel>>;
            //Assert.AreEqual(results.Content.ToList().Single(), employee);

        }
    }
}
