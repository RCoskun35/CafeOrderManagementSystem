namespace CafeOrderManagementSystem.Domain.Entities
{
    public class OrderDetail:BaseEntity
    {
        
        public int OrderId { get; set; }
        public int ProductId { get; set; } 
        public int? MenuId { get; set; } 
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; } 
        public Order Order { get; set; }
        public Product Product { get; set; }
        public Menu? Menu { get; set; }
    }
}
