using Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery : IGetCustomersListQuery
    {
        private readonly ICustomerRepository _repository;

        public GetCustomersListQuery(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CustomerModel> Execute()
        {
            var customers = _repository.GetAll()
                .Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return customers.ToList();
        }
    }
    }
}
