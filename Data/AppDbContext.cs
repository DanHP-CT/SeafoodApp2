using Microsoft.EntityFrameworkCore;
using SeafoodApp.Models;

namespace SeafoodApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Nhà cung cấp, đơn mua
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        // Đơn sản xuất
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionOrderDetail> ProductionOrderDetails { get; set; }

        // Phiếu chế biến và chi tiết
        public DbSet<ProcessingTicket> ProcessingTickets { get; set; }
        public DbSet<ProcessingTicketInputDetail> ProcessingTicketInputDetails { get; set; }
        public DbSet<ProcessingTicketOutputDetail> ProcessingTicketOutputDetails { get; set; }

        // Kho lạnh, công đoạn, mức lương
        public DbSet<ColdInventory> ColdInventories { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<WageRate> WageRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PurchaseOrder ↔ PurchaseOrderDetail
            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.Details)
                .WithOne(d => d.PurchaseOrder)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProductionOrder ↔ ProductionOrderDetail
            modelBuilder.Entity<ProductionOrder>()
                .HasMany(po => po.Details)
                .WithOne(d => d.ProductionOrder)
                .HasForeignKey(d => d.ProductionOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProcessingTicket ↔ InputDetails
            modelBuilder.Entity<ProcessingTicket>()
                .HasMany(t => t.InputDetails)
                .WithOne(d => d.ProcessingTicket)
                .HasForeignKey(d => d.ProcessingTicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProcessingTicket ↔ OutputDetails
            modelBuilder.Entity<ProcessingTicket>()
                .HasMany(t => t.OutputDetails)
                .WithOne(d => d.ProcessingTicket)
                .HasForeignKey(d => d.ProcessingTicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Các cấu hình bổ sung (nếu cần)
            // ví dụ: modelBuilder.Entity<Supplier>().Property(s => s.Name).IsRequired();
        }
    }
}
