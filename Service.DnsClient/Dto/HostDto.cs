using DnsClient;

namespace Service.DnsClient.Controller
{
    public class HostDto
    {
        public string HostName     { get; set; }
        public QueryType Type { get; set; }
    }
}
