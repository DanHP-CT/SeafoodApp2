namespace SeafoodApp.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime SupplyDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string BatchNumber { get; set; } = string.Empty;
        public ICollection<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();
    }
}
