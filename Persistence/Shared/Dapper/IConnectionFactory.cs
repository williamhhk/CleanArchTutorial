using System.Data;

namespace Persistence.Shared.Dapper
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}