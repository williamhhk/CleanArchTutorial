
using Application.Interfaces.Persistence;
using Persistence.Shared.EntityFramework;

namespace Persistence.Shared
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _database;

        public EfUnitOfWork(IDatabaseContext database)
        {
            _database = database;
        }

        public void Save()
        {
            _database.Save();
        }
    }
}
