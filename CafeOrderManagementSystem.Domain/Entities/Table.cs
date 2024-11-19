namespace CafeOrderManagementSystem.Domain.Entities
{
    public class Table: BaseEntity
    {
        public string TableNumber { get; set; } = string.Empty; 
        public int State { get; set; } = 0 ; 

        public ICollection<Order> Orders { get; set; }
    }
}
