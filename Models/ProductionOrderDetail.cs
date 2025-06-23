namespace SeafoodApp.Models
{
    public class ProductionOrderDetail
    {
        public int Id { get; set; }
        public int ProductionOrderId { get; set; }
        public ProductionOrder? ProductionOrder { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Packaging { get; set; } = string.Empty; // Đóng gói
        public int Quantity { get; set; }                     // Số lượng cần sản xuất
        public string Note { get; set; } = string.Empty;      // Ghi chú
    }
}
