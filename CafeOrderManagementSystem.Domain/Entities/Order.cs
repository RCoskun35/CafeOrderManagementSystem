namespace CafeOrderManagementSystem.Domain.Entities
{
    public class Order: BaseEntity
    {
        public int TableId { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        public DateTime? CompletionDate { get; set; }
        public bool Status { get; set; } = false;
        public Table Table { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
