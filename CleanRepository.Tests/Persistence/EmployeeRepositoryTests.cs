
using Moq;
using NUnit.Framework;
using Persistence.Employees;
using Persistence.Shared.EntityFramework;

namespace CleanRepository.Tests.Persistence
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        [Test]
        public void EmployeeRepositoryTests_ConstructorShouldCreateRepository_No_Error()
        {
            var context = new Mock<IDatabaseContext>();
            var repository = new EmployeeRespository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
