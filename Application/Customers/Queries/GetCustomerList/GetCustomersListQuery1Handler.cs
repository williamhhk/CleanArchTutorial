using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery1Handler : IRequestHandler<GetCustomersListQuery1, List<CustomerModel>>
    {
        private readonly IGetCustomersListQuery _query;
        // Just inject repository in here 

        public GetCustomersListQuery1Handler(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public List<CustomerModel> Handle(GetCustomersListQuery1 message)
        {

            return _query.Execute().ToList();
        }
    }
}
