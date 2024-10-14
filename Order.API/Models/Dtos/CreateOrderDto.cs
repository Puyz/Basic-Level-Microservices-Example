namespace Order.API.Models.Dtos
{
    public class CreateOrderDto
    {
        public Guid BuyerId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
