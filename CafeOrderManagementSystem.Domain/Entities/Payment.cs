﻿namespace CafeOrderManagementSystem.Domain.Entities
{
    public class Payment:BaseEntity
    {
        public int OrderId { get; set; } 
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; 
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public Order Order { get; set; }
    }
}
