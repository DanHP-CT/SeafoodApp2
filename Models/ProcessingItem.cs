namespace SeafoodApp.Models
{
    public class ProcessingItem
    {
        public int Id { get; set; }
        public int ProcessingTicketId { get; set; }
        public ProcessingTicket? ProcessingTicket { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public string BatchNumber { get; set; } = string.Empty;
    }
}
