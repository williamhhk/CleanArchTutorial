using Application.Customers.Queries.GetCustomerList;
using Domain.Customers;
using MediatR;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Customers
{
    public class CustomersController : ApiController
    {

        private readonly IGetCustomersListQuery _query;
        private readonly IMediator _mediator;

        public CustomersController(IGetCustomersListQuery query, IMediator mediator)
        {
            _mediator = mediator;
            _query = query;
        }

        public IHttpActionResult Get()
        {
            //return Ok();
            return Ok(_query.Execute());
        }

        public IHttpActionResult Create()
        {
            //  Send Command or Publish Notification ?

            _mediator.Send(new CustomerCreated()
            {
                Customer = Customer.Create(10, "Demoing")
            });
            return Ok();
        }
    }
}
