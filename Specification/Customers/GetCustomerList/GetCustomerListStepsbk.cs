using Application.Customers.Queries.GetCustomerList;
using Autofac;
using Specification.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Specification.Customers.GetCustomerList
{
    [Binding]
    public sealed class GetCustomerListStepsbk
    {
        [Binding]
        public class GetCustomersListSteps
        {
            private readonly AppContext _context;
            private List<CustomerModel> _results;

            public GetCustomersListSteps(AppContext context)
            {
                _context = context;
            }

            [When(@"I request a list of customers")]
            public void WhenIRequestAListOfCustomers()
            {
               
                var query = _context.Container.Resolve<GetCustomersListQuery>();
                var list = query.Execute();

            }

            [Then(@"the following customers should be returned:")]
            public void ThenTheFollowingCustomersShouldBeReturned(Table table)
            {

            }
        }
    }
}
