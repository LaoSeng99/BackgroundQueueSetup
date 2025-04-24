namespace BackgroundQueueSetup.Models;

public class AuditLogEntry
{
    public int Id { get; set; }
    public string Action { get; set; } = "";
    public string UserId { get; set; } = "";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Details { get; set; } = "";
}
