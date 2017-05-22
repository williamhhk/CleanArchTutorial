using Application.Interfaces.Persistence;
using Domain.Customers;


namespace Persistence.Customers
{
    public class CustomerRepository
        : Repository<Customer>,
        ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext database)
            : base(database) { }
    }
}
