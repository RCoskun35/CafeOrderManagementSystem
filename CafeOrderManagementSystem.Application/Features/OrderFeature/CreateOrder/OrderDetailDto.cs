namespace CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder
{
    public class OrderDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? MenuId { get; set; }
    }
}
