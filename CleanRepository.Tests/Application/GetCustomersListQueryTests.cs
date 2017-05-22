using Application.Customers.Queries.GetCustomerList;
using Application.Interfaces.Persistence;
using AutoMoq;
using Domain.Customers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CleanRepository.Tests.Application
{
    [TestFixture]
    public class GetCustomersListQueryTests
    {
        private GetCustomersListQuery _query;
        private AutoMoqer _mocker;
        private Customer _customer;
        private IEnumerable<Customer> _customers;

        private const int Id = 1;
        private const string Name = "Customer 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _customer = new Customer()
            {
                Id = Id,
                Name = Name
            };
            
            _customers = new List<Customer>()
            {
                _customer
            };

            _mocker.GetMock<ICustomerRepository>()
                .Setup(p => p.GetAll())
                .Returns(_customers.AsQueryable());

            _query = _mocker.Create<GetCustomersListQuery>();
        }

        [Test]
        public void GetCustomersListQueryTests_TestExecuteShouldReturnListOfCustomers_No_Error()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
