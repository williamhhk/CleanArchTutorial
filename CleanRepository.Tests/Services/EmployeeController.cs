using Application.Employees.Queries;
using AutoMoq;
using NUnit.Framework;
using Service.Employees;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;


namespace CleanRepository.Tests.Services
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeesController _controller;
        private AutoMoqer _mocker;
        private IGetEmployeesListQuery _query;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();
            //_controller = _mocker.Create<EmployeesController>();
            //_query = _mocker.Create<IGetEmployeesListQuery>();

        }

        [Test]
        public void EmployeeControllerTests_ConstructorShouldReturnList_No_Error()
        {
            var employee = new EmployeeModel() { Id = 1, Name = "William Han" };

            _mocker.GetMock<IGetEmployeesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<EmployeeModel> { employee });

            _query = _mocker.Create<IGetEmployeesListQuery>();
            var controller = new EmployeesController(_query);
            //System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.IEnumerable<Application.Employees.Queries.EmployeeModel>>
            var results = controller.Get() as System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.IEnumerable<EmployeeModel>>;
            Assert.AreEqual(results.Content.ToList().Single(), employee);

        }
    }
}
