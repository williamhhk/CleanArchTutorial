using MediatR;
using Newtonsoft.Json;
using Serilog;
using System;

namespace Application.Common
{
    public class QueryExecuted : DomainEvent, INotification
    {
        public override void Flatten()
        {
            throw new NotImplementedException();
        }

        public QueryExecuted(string query)
        {
            this.Args.Add("Query String", query);
        }
    }

    public class QueryExcecutedHandler : INotificationHandler<QueryExecuted>
    {
        private readonly ILogger _logger;

        public QueryExcecutedHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(QueryExecuted notification)
        {
            _logger?.Information(JsonConvert.SerializeObject(notification));
        }
    }
}
