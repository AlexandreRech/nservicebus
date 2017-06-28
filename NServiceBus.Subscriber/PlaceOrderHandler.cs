using System.Threading.Tasks;
using NServiceBus.Logging;
using NServiceBus.Shared;

namespace NServiceBus.Subscriber
{
    public class PlaceOrderHandler :
        IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Ordem para produto {message.Product} adicionada com id {message.Id}");
            log.Info($"Publicando: ordem com id {message.Id}");

            var orderPlaced = new OrderPlaced
            {
                OrderId = message.Id
            };
            return context.Publish(orderPlaced);
        }
    }
}
