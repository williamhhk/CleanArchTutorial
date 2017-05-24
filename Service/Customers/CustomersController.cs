using Application.Customers.Queries.GetCustomerList;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Customers
{
    public class CustomersController : ApiController
    {

        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public IHttpActionResult Get()
        {
            return Ok();
            //return Ok(_query.Execute());
        }

        public IHttpActionResult Create()
        {
            // Create Customer
            // Send command...

            return Ok();
            //return Ok(_query.Execute());
        }
    }
}
