using System;
using Application.Interfaces.Persistence;
using System.Data;

namespace Persistence.Shared.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        public void Save()
        {
            _transaction.Commit();
        }
    }
}
