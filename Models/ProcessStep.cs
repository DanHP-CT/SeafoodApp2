namespace SeafoodApp.Models
{
    public class ProcessStep
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InputMaterial { get; set; } = string.Empty;
        public string OutputMaterial { get; set; } = string.Empty;
        public string Standard { get; set; } = string.Empty;

        public ICollection<ProcessingTicket> ProcessingTickets { get; set; } = new List<ProcessingTicket>();
    }
}
