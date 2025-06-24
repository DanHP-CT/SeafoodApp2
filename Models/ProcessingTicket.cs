using System.ComponentModel.DataAnnotations;

namespace SeafoodApp.Models
{
    public class ProcessingTicket
    {
        public int Id { get; set; }

        [Display(Name = "Số phiếu")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "Ngày chế biến")]
        public DateTime ProcessingDate { get; set; } = DateTime.Now;

        [Display(Name = "Lệnh sản xuất")]
        public int ProductionOrderId { get; set; }

        [Display(Name = "Công đoạn")]
        public int ProcessStepId { get; set; }

        [Display(Name = "Bộ phận")]
        public string Department { get; set; } = string.Empty;

        [Display(Name = "Số nhân công")]
        public int WorkerCount { get; set; }

        [Display(Name = "Thời gian (giờ)")]
        public int DurationHours { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; } = string.Empty;

        [Display(Name = "Hoàn thành")]
        public bool IsCompleted { get; set; }

        // Navigation
        public ICollection<ProcessingTicketInputDetail> InputDetails { get; set; } = new List<ProcessingTicketInputDetail>();
        public ICollection<ProcessingTicketOutputDetail> OutputDetails { get; set; } = new List<ProcessingTicketOutputDetail>();
    }
}
