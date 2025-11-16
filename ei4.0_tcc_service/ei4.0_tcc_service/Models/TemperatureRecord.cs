namespace TemperatureDb.Models
{
    public class TemperatureRecord
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}