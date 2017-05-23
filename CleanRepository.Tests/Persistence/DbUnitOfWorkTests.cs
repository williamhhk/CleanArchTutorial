using AutoMoq;
using NUnit.Framework;
using Persistence.Shared;

namespace CleanRepository.Tests.Persistence
{
    [TestFixture]
    public class DbUnitOfWorkTests
    {
        private EfUnitOfWork _unitOfWork;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _unitOfWork = _mocker.Create<EfUnitOfWork>();
        }

        [Test]
        public void DbUnitOfWorkTests_SaveShouldSaveUnitOfWork_No_Error()
        {
            _unitOfWork.Save();
        }
    }
}
