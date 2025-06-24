using System.ComponentModel.DataAnnotations;

namespace SeafoodApp.Models
{
    public class ProcessingTicketOutputDetail
    {
        public int Id { get; set; }
        public int ProcessingTicketId { get; set; }

        // Khởi tạo navigation property để không báo non-nullable
        public ProcessingTicket ProcessingTicket { get; set; } = null!;

        [Display(Name = "Sản phẩm đầu ra")]
        public string MaterialName { get; set; } = string.Empty;

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Số lô")]
        public string BatchNumber { get; set; } = string.Empty;
    }
}
