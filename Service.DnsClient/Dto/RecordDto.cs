using System.Collections.Generic;

namespace Service.DnsClient.Controller
{
    public class RecordDto
    {
        public IEnumerable<string> HostName { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }
    }
}
