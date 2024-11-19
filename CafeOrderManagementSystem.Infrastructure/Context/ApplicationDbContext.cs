using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CafeOrderManagementSystem.Infrastructure.Context
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Log> Logs{ get; set; }
        public DbSet<MenuProduct> MenuProducts{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuProduct>(entity =>
            {
                entity.ToTable("MenuProducts"); 
                entity.HasKey(mp => new { mp.MenuId, mp.ProductId });
                entity.Property(mp => mp.MenuId)
                      .HasColumnName("MenuId");
                entity.Property(mp => mp.ProductId)
                      .HasColumnName("ProductId");
            });
            builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        
        }
    }
}
