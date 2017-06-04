using Application.Interfaces.Persistence;
using Domain.Customers;
using Persistence.Shared.Dapper;

namespace Persistence.Customers
{
    public class DapperCustomerRepository : DapperRepository<Customer>, ICustomerRepository
    {
        public DapperCustomerRepository(IConnectionFactory database) : base(database)
        {
        }
    }
}