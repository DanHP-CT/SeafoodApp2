using System.ComponentModel.DataAnnotations;

namespace SeafoodApp.Models
{
    public class ProcessingTicketDetail
    {
        public int Id { get; set; }
        public int ProcessingTicketId { get; set; }
        public ProcessingTicket? ProcessingTicket { get; set; }

        [Display(Name = "Nguyên liệu/Sản phẩm")]
        public string MaterialName { get; set; } = string.Empty;

        [Display(Name = "Size")]
        public string Size { get; set; } = string.Empty;

        [Display(Name = "Số lô")]
        public string BatchNumber { get; set; } = string.Empty;

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        /// <summary>
        /// true = đầu vào, false = đầu ra
        /// </summary>
        public bool IsInput { get; set; }
    }
}
