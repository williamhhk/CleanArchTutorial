using System.Collections.Generic;

namespace Application.Employees.Queries
{
    public interface IGetEmployeesListQuery
    {
        IEnumerable<EmployeeModel> Execute();
    }
}