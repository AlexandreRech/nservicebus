using System.Threading.Tasks;
using NServiceBus.Logging;
using NServiceBus.Shared;

namespace NServiceBus.Subscriber
{
    public class OrderCreatedHandler :
        IHandleMessages<OrderPlaced>
    {
        static ILog log = LogManager.GetLogger<OrderCreatedHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            log.Info($"Subscriber: {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
