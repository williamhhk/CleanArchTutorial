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
            _memRepository.Add(new Customer { Id = 1, Name = "William Han" });
            _memRepository.Add(new Customer { Id = 2, Name = "Uncle Bob" });
            _memRepository.Add(new Customer { Id = 1, Name = "Martin Fowler" });
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
