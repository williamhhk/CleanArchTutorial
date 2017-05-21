namespace Application.Customers.Queries.GetCustomerList
{
    using System.Collections.Generic;

    public interface IGetCustomersListQuery
    {
        IEnumerable<CustomerModel> Execute();
    }
}