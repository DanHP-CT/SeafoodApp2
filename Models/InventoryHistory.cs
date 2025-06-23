using System;

namespace SeafoodApp.Models
{
    public class InventoryHistory
    {
        public int Id { get; set; }
        public string LotCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
