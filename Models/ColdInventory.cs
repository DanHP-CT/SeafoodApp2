using System;

namespace SeafoodApp.Models
{
    public class ColdInventory
    {
        public int Id { get; set; }
        public string LotCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public int Stock { get; set; }
        public DateTime InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
