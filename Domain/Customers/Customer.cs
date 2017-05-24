using Domain.Common;
using MediatR;
using System;

namespace Domain.Customers
{
    public class Customer : IEntity
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public static Customer Create(int id, string Name)
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Name");

            Customer customer = new Customer()
            {
                Id = id,
                Name = Name
            };
            return customer;
        }
    }
}
