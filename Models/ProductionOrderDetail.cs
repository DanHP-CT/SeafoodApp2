using System;

namespace SeafoodApp.Models
{
    public class ProductionOrderDetail
    {
        public int Id { get; set; }

        // Khóa ngoại về ProductionOrder
        public int ProductionOrderId { get; set; }
        public ProductionOrder? ProductionOrder { get; set; }

        // Thông tin chi tiết
        public string ProductName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Packaging { get; set; } = string.Empty;  // Đóng gói
        public int Quantity { get; set; }                       // Số lượng cần sản xuất

        // Cho phép để trống
#nullable enable
        public string? Note { get; set; }
#nullable restore
    }
}
