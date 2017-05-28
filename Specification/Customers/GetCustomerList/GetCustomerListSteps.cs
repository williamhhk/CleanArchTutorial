using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Specification.Customers.GetCustomerList
{
    [Binding]
    public sealed class GetCustomerListSteps
    {
        [Binding]
        public class GetCustomersListSteps
        {
            [When(@"I request a list of customers")]
            public void WhenIRequestAListOfCustomers()
            {

            }

            [Then(@"the following customers should be returned:")]
            public void ThenTheFollowingCustomersShouldBeReturned(Table table)
            {

            }
        }
    }
}
