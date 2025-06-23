namespace SeafoodApp.Models
{
    public class WageRate
    {
        public int Id { get; set; }
        public string ProcessStepName { get; set; } = string.Empty;
        public decimal Rate { get; set; }
    }
}
