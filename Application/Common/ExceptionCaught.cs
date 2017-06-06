using MediatR;
using Newtonsoft.Json;
using Serilog;
using System;


namespace Application.Common
{
    public class ExceptionCaught : DomainEvent, INotification
    {
        public override void Flatten()
        {
            throw new NotImplementedException();
        }

        public ExceptionCaught(string message)
        {
            this.Args.Add("Message ", message);
        }
    }

    public class ExceptionCaughtHandler : INotificationHandler<ExceptionCaught>
    {
        private readonly ILogger _logger;

        public ExceptionCaughtHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(ExceptionCaught notification)
        {
            _logger?.Information(JsonConvert.SerializeObject(notification));
        }
    }
}
