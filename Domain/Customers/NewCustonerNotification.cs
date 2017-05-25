using MediatR;
using System;


namespace Domain.Customers
{
    public class NewCustonerNotification : INotification
    {
        public string Name { get; set; }
    }
}
