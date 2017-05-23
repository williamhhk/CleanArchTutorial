using System;
using Application.Interfaces.Persistence;
using Domain.Common;
using System.Linq;

namespace Persistence.Shared.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDatabaseContext _database;

        public Repository(IDatabaseContext database)
        {
            _database = database;
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public T Get(int id)
        {
            return _database.Set<T>().Single(p => p.Id == id);
        }

        public System.Linq.IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }
    }
}
