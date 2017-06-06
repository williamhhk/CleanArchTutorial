namespace Application.EventLog
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using System.Collections.Generic;
    using Application.Interfaces.Persistence;
    using Dapper;
    using System.Linq;
    using Application.Common;

    public class EventLogQuery
    {
        public class Query : IRequest<List<Model>>
        {
            public int Id { get; set; }
        }

        public class Model
        {
            public string Message { get; set; }
            public string Level { get; set; }
            public string LogEvent { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, List<Model>>
        {
            private readonly IDemoDbConnectionFactory _db;
            private readonly IMediator _mediator;
            public QueryHandler(IDemoDbConnectionFactory db, IMediator mediator)
            {
                _db = db;
                _mediator = mediator;
            }

            public async Task<List<Model>> Handle(Query message)
            {
                var queryStr = $@"SELECT TOP 1000 [Id]
                                  ,[Message]
                                  ,[Level]
                                  ,[LogEvent]
                              FROM [EventsLog].[dbo].[Logs]";
                IEnumerable<Model> results = Enumerable.Empty<Model>();
                try
                {
                   results =  await _db.GetConnection.QueryAsync<Model>(queryStr).ConfigureAwait(false);
                    _mediator?.Publish(new QueryExecuted("Successfully executed"));
                    return results.ToList();

                }
                catch (Exception ex)
                {
                    //// create a notification to send it to logger
                    //var tcs = new TaskCompletionSource<Model>();
                    //tcs.SetResult(new Model());
                    //return results.ToList();
                    _mediator?.Publish(new ExceptionCaught(ex.Message));
                }
                return new List<Model>();
            }
        }
    }
}