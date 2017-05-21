
using Domain.Employees;
using NUnit.Framework;

namespace CleanRepository.Tests.Domain
{
    [TestFixture]
    public class EmployeeTests
    {
        private readonly Employee _employee;
        private const int Id = 1;
        private const string Name = "Test";


        public EmployeeTests()
        {
            _employee = new Employee();
        }

        [Test]
        public void EmployeeTests_TestSetAndGetId_No_Error()
        {
            _employee.Id = Id;

            Assert.That(_employee.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void EmployeeTests_TestSetAndGetName_No_Error()
        {
            _employee.Name = Name;

            Assert.That(_employee.Name,
                Is.EqualTo(Name));
        }
    }
}
