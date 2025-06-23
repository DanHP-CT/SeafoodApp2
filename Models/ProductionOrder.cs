using System;
using System.Collections.Generic;

namespace SeafoodApp.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string ContractNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime? PackagingSupplyDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<ProductionOrderDetail> Details { get; set; } = new List<ProductionOrderDetail>();
    }
}
