using Domain.Interfaces;

namespace Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
