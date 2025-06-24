using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeafoodApp.Models
{
    [Table("PurchaseOrderDetails")]
    public class PurchaseOrderDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PurchaseOrder))]
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = null!;

        [Column("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [Column("BatchNumber")]
        public string BatchNumber { get; set; } = string.Empty;

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Quantity")]
        public decimal Quantity { get; set; }

        [NotMapped]
        public decimal Amount => Price * Quantity;
    }
}
