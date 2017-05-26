using Domain.Customers;
using NUnit.Framework;

namespace CleanRepository.Tests.Domain
{
    [TestFixture]
    public class CustomerTests
    {
        private readonly Customer _customer;
        private const int Id = 1;
        private const string Name = "This is a test";

        public CustomerTests()
        {
            _customer = Customer.Create(Id, Name);
        }

        [Test]
        public void CustomerTests_TestSetAndGetId_No_Error()
        {

            Assert.That(_customer.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void CustomerTests_TestSetAndGetName_No_Error()
        {

            Assert.That(_customer.Name,
                Is.EqualTo(Name));
        }

        [Test]
        public void CustomerTests_TestSetAndGetId_Not_Equal_No_Error()
        {
            Assert.That(_customer.Id, Is.Not.EqualTo(Id));
        }
    }
}
