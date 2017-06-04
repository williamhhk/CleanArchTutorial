using System.Data;
namespace Application.Interfaces.Persistence
{
    public interface IDemoConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
