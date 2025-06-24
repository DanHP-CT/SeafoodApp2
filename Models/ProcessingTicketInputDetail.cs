using System.ComponentModel.DataAnnotations;

namespace SeafoodApp.Models
{
    public class ProcessingTicketInputDetail
    {
        public int Id { get; set; }
        public int ProcessingTicketId { get; set; }

        // Khởi tạo navigation property để không báo non-nullable
        public ProcessingTicket ProcessingTicket { get; set; } = null!;

        [Display(Name = "Sản phẩm đầu vào")]
        public string MaterialName { get; set; } = string.Empty;

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Số lô")]
        public string BatchNumber { get; set; } = string.Empty;
    }
}
