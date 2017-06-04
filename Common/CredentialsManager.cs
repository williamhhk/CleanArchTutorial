using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Common
{
    public class CredentialsManager : ICredentialsManager
    {
        public string GetAppSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            return WebConfigurationManager.ConnectionStrings[key];
        }

        public virtual string Domain => GetAppSetting("Domain");
    }
}
