using System.Configuration;

namespace Common
{
    public interface ICredentialsManager
    {
        string GetAppSetting(string key);
        ConnectionStringSettings GetConnectionString(string key);
    }
}