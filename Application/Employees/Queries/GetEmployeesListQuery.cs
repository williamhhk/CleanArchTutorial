using Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Queries
{
    public class GetEmployeesListQuery : IGetEmployeesListQuery
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeesListQuery(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeModel> Execute()
        {
            var customers = _repository.GetAll()
                .Select(p => new EmployeeModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return customers.ToList();
        }
    }

}
