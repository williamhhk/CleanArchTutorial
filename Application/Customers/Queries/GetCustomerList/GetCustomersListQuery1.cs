using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery1 : IRequest<List<CustomerModel>>
    {
    }
}



