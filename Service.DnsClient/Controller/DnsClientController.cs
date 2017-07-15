using DnsClient;
using System.Web.Http;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Service.DnsClient.Dto;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;
using System.Web.Http.Description;
using System.Net.Http;
using System.Web;
using System.Diagnostics;

namespace Service.DnsClient.Controller
{
    [RoutePrefix("api/dnsclient")]
    public class DnsClientController : ApiController
    {
        ILookupClient _client;
        public DnsClientController(ILookupClient client)
        {
            _client = client;
        }


        [HttpGet, Route("{hostName}/{type}", Name = "GetIPByHostname")]
        public IHttpActionResult GetIPByHostname(string hostName, QueryType type)
        {

            var client = new LookupClient();
            IDnsQueryResponse result = null;
            RecordDto record = new RecordDto() { HostName = new List<string>() { hostName }, Type = type.ToString() };
            switch (type)
            {
                default:
                case QueryType.A:
                    result = _client.Query(hostName, QueryType.A);
                    record.IPAddress = result.Answers.ARecords().FirstOrDefault().Address.ToString();
                    break;
                case QueryType.AAAA:

                    result = _client.Query(hostName, QueryType.AAAA);
                    record.IPAddress = result.Answers.AaaaRecords().FirstOrDefault().Address.ToString();
                    break;
            };
            var linkedResource = new
            {
                value = record,
                links = CreateLinks(record)
            };
            return Ok(linkedResource);
        }

        //https://www.statdns.com/api/
        //http://localhost:59604/api/dnsclient/x/216.58.193.197/
        [HttpGet]
        [Route("x/{ipAddress}", Name = "GetHostNameByIP")]
        public IHttpActionResult GetHostNameByIP(string ipAddress)
        {
            IDnsQueryResponse result = null;
            RecordDto hostName = new RecordDto() { IPAddress = ipAddress};
            result = _client.QueryReverse(IPAddress.Parse(ipAddress));
            hostName.HostName = result.Answers.PtrRecords().Select(name => name.PtrDomainName.ToString());
            return Ok(hostName);
        }


        //http://localhost:59604/api/dnsclient/x?ipAddress=216.58.193.197
        [HttpGet]
        [Route("x", Name = "GetHostNameByIP1")]
        public IHttpActionResult GetHostNameByIP1([FromUri] string ipAddress)
        {
            IDnsQueryResponse result = null;
            RecordDto hostName = new RecordDto() { IPAddress = ipAddress };
            result = _client.QueryReverse(IPAddress.Parse(ipAddress));
            hostName.HostName = result.Answers.PtrRecords().Select(name => name.PtrDomainName.ToString());
            return Ok(hostName);
        }

        //  Add HATOEAS
        private IEnumerable<Link> CreateLinks(RecordDto record)
        {
            var links = new[]
            {
                new Link
                {
                    Method = "GET",
                    Rel = "self",
                    Href = Url.Link("GetIPByHostname", new { hostname = record.HostName.FirstOrDefault()})
                },
                new Link
                {
                    Method = "GET",
                    Rel = "x",
                    Href = Url.Link("GetHostNameByIP", new { ipAddress = record.IPAddress})
                },
            };
            return links;
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult GetTest()
        {
            var result = new
            {
                Number = 1,
                FieldAbc = "Abc"
            };

            return Ok(result);
        }



        [HttpPost]
        [Route("files")]
        [ResponseType(typeof(FileUpload))]
        public async System.Threading.Tasks.Task<IHttpActionResult> PostFileUploadAsync()
        {

            var request = Request.Content.IsMimeMultipartContent();
            var streamProvider = new MultipartFormDataStreamProvider("f:\\upload");
            await Request.Content.ReadAsMultipartAsync(streamProvider);

            return Ok();

        }

    }
}
