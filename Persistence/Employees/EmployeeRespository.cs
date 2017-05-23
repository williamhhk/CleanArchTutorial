using Application.Interfaces.Persistence;
using Domain.Employees;
using Persistence.Shared.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Employees
{
    public class EmployeeRespository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRespository(IDatabaseContext database) : base(database)
        {
        }
    }

}
