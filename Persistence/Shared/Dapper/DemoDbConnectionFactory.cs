using Application.Interfaces.Persistence;


namespace Persistence.Shared.Dapper
{
    public class DemoDbConnectionFactory : ConnectionFactory, IDemoDbConnectionFactory
    {
        public DemoDbConnectionFactory(string connectionStr) : base(connectionStr)
        {
        }
    }
}
