using MediatR;
using Serilog;

namespace Domain.Customers
{
    public class SuccessfullyRegistered : INotificationHandler<NewCustonerNotification>
    {
        public void Handle(NewCustonerNotification notification)
        {
            Log.Information("Successfully send notification to customer");
        }
    }
}
