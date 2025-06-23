namespace SeafoodApp.Models
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }

        public string Size { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // Tính thành tiền
        public decimal Amount => UnitPrice * Quantity;
    }
}
