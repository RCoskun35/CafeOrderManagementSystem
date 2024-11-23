using CafeOrderManagementSystem.Domain.Entities;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable
{
    public class TableDto
    {
        public string TableNumber { get; set; } = string.Empty;
        public int State { get; set; } = 0;
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Order? Order { get; set; }

    }
}
