using Application.Customers.Queries.GetCustomerList;
using Domain.Customers;
using MediatR;
using Service.Common;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Threading.Tasks;
using Application.EventLog;

namespace Service.Customers
{
    [RoutePrefix("api/v1")]
    public class CustomersController : ApiControllerBase
    {

        //private readonly IGetCustomersListQuery _query;
        private readonly IMediator _mediator;

        public CustomersController(
            /*IGetCustomersListQuery query,*/
            IMediator mediator)
        {
            _mediator = mediator;
            //_query = query;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            // use mediator to send in a query ....
            // create a new class e.g. QueryCustomersList
            // return the results.
            var list = _mediator.Send(new GetCustomersListQuery1());
            return Ok(list.Result);

            //return Ok();
            //return Ok(_query.Execute());
        }

        [HttpGet]
        [Route("async")]
        public async Task<IHttpActionResult> GetAsync()
        {
            return await CreateHttpResponseAsync(() =>
             {
                 return Ok(_mediator.Send(new GetCustomersListQuery1()).Result);
             });

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

        public IHttpActionResult Delete()
        {
            return CreateHttpResponse(() =>
           {
               throw new System.Exception();
           });
        }

        [HttpGet]
        [Route("dapperquery")]
        public async Task<IHttpActionResult> DapperQuery()
        {
            return await CreateHttpResponseAsync(() =>
            {
                return Ok(_mediator.Send(new EventLogQuery.Query()).Result);
            });

        }

    }
}
