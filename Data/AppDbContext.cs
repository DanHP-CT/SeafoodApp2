using Microsoft.EntityFrameworkCore;
using SeafoodApp.Models;

namespace SeafoodApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionOrderDetail> ProductionOrderDetails { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<ProcessingTicket> ProcessingTickets { get; set; }
        public DbSet<ProcessingItem> ProcessingItems { get; set; }
        public DbSet<ColdInventory> ColdInventories { get; set; }
        public DbSet<InventoryHistory> InventoryHistories { get; set; }
        public DbSet<WageRate> WageRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ProductionOrder - ProductionOrderDetail (1-nhiều)
            modelBuilder.Entity<ProductionOrderDetail>()
                .HasOne(d => d.ProductionOrder)
                .WithMany(o => o.Details)
                .HasForeignKey(d => d.ProductionOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // PurchaseOrder - PurchaseOrderDetail (1-nhiều)
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasOne(d => d.PurchaseOrder)
                .WithMany(o => o.Details)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // (Bạn có thể bổ sung quan hệ khác ở đây nếu có thêm module)
        }
    }
}
