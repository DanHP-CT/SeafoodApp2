using System;
using System.Collections.Generic;

namespace SeafoodApp.Models
{
    public class ProcessingTicket
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime ProcessingDate { get; set; }
        public int ProductionOrderId { get; set; }
        public ProductionOrder? ProductionOrder { get; set; }
        public int ProcessStepId { get; set; }
        public ProcessStep? ProcessStep { get; set; }
        public string Department { get; set; } = string.Empty;
        public int WorkerCount { get; set; }
        public double DurationHours { get; set; }
        public ICollection<ProcessingItem> ProcessingItems { get; set; } = new List<ProcessingItem>();
        public bool IsCompleted { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
