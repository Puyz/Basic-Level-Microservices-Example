using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Order.API.Models.Enums;
using Shared.Events;

namespace Order.API.Consumer
{
    public class PaymentCompletedEventConsumer : IConsumer<PaymentCompletedEvent>
    {
        private readonly OrderDbContext _orderDbContext;

        public PaymentCompletedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            Order.API.Models.Entities.Order order = await _orderDbContext.Orders.FirstOrDefaultAsync(o => o.OrderId.Equals(context.Message.OrderId));

            order.OrderStatus = OrderStatus.Completed;

            await _orderDbContext.SaveChangesAsync();
        }
    }
}
