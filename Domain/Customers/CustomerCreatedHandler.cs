using System;
using MediatR;
using System.Diagnostics;

namespace Domain.Customers
{
    public class CustomerCreatedHandler : IRequestHandler<CustomerCreated>
    {
        // Repo
        // DI Logging Repo
        // Add Constructor to inject Interface.
        //

        public void Handle(CustomerCreated message)
        {
            Trace.WriteLine("This is a test");
            //  Log to DB.
        }
    }
}
