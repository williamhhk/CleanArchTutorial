using System;
using System.Data;
using System.Data.Common;

namespace Persistence.Shared.Dapper
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = "Server=;Database=;User ID=;Password=!";

        public ConnectionFactory()
        {
        }

        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
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
