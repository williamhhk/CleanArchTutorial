using System;
using System.Data;
using System.Data.Common;

namespace Persistence.Shared.Dapper
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionStr)
        {
            _connectionString = connectionStr;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = _connectionString;
                conn.Open();
                return conn;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
