using Application.Interfaces.Persistence;
using Domain.Customers;
using Persistence.Shared.EntityFramework;

namespace Persistence.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
