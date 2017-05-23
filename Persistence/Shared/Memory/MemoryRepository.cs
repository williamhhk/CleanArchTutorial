using Application.Interfaces.Persistence;
using Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Memory.Shared
{
    public class MemoryRepository<T> : IRepository<T>  where T :class, IEntity
    {
        protected static List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }
       
        public T Get(int id)
        {
            return _entities.Where(p=>p.Id == id).FirstOrDefault();
        }
    }
}
