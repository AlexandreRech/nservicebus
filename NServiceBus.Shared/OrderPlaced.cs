using System;

namespace NServiceBus.Shared
{
    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
