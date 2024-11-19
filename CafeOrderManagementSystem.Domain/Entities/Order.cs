namespace CafeOrderManagementSystem.Domain.Entities
{
    public class Order: BaseEntity
    {
        public int TableId { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; } 
        public Table Table { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
