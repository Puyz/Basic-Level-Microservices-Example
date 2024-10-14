using Shared.Events.Common;

namespace Shared.Events
{
    public class StockNotReservedEvent : IEvent
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }
        public string Message { get; set; }
    }
}
