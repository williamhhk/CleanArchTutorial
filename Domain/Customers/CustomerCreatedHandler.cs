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
        private readonly IMediator _mediator;

        public CustomerCreatedHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        public void Handle(CustomerCreated message)
        {
            _mediator.Publish(new NewCustonerNotification() { Name = "Notifying..." });
            Trace.WriteLine("This is a test");
            //  Log to DB.
        }
    }
}
