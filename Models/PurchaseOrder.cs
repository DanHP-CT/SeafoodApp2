using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeafoodApp.Models
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }

        [Column("Code"), Required]
        public string Code { get; set; } = string.Empty;

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("SupplyDate")]
        public DateTime SupplyDate { get; set; }

        public List<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();


        [NotMapped]
        public decimal TotalQuantity => Details.Sum(d => d.Quantity);

        [NotMapped]
        public decimal TotalAmount => Details.Sum(d => d.Amount);
    }
}
