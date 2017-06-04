namespace Application.EventLog
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using System.Data;
    using System.Collections.Generic;
    using Application.Interfaces.Persistence;
    using Dapper;
    using System.Linq;

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
            public QueryHandler(IDemoDbConnectionFactory db)
            {
                _db = db;
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
                    return results.ToList();

                }
                catch (Exception ex)
                {
                var tcs = new TaskCompletionSource<Model>();
                tcs.SetResult(new Model());
                return results.ToList();

                }
            }
        }

        //public class CommandHandler : AsyncRequestHandler<Command>
        //{
        //    private readonly SchoolContext _db;

        //    public CommandHandler(SchoolContext db)
        //    {
        //        _db = db;
        //    }

        //    protected override async Task HandleCore(Command message)
        //    {
        //        var student = await _db.Students.FindAsync(message.ID);

        //        _db.Students.Remove(student);
        //    }
        //}

    }
}