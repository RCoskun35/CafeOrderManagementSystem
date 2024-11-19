namespace CafeOrderManagementSystem.Domain.Entities
{
    public class MenuProduct
    {
        public int MenuId { get; set; } 
        public int ProductId { get; set; } 
        public Menu Menu { get; set; }
        public Product Product { get; set; }
    }
}
