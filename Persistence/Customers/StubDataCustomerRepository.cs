using System;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Customers;
using Persistence.Memory.Shared;

namespace Persistence.Customers
{
    public sealed class StubDataCustomerRepository : ICustomerRepository
    {
        readonly MemoryRepository<Customer> _memRepository;

        public StubDataCustomerRepository(MemoryRepository<Customer> memRepository)
        {
            this._memRepository = memRepository;
            _memRepository.Add(Customer.Create(1, "William Han"));
            _memRepository.Add(Customer.Create(2, "Martin Fowler"));
            _memRepository.Add(Customer.Create(3, "Uncle Bob"));
        }


        public void Add(Customer entity)
        {
            _memRepository.Add(entity);
        }

        public Customer Get(int id)
        {
            return _memRepository.Get(id);
        }

        public IQueryable<Customer> GetAll()
        {
            return _memRepository.GetAll();
        }

        public void Remove(Customer entity)
        {
            _memRepository.Remove(entity);
        }
    }
}
