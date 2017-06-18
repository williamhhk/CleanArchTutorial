using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.DnsClient.Dto
{
    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}