using BackgroundQueueSetup.Models;

namespace BackgroundQueueSetup.Services;

public interface IAuditLogService
{
    Task WriteAsync(AuditLogEntry entry, CancellationToken ct);
}
public class AuditLogService(
        //  IAuditLogRepository repo
        ) : IAuditLogService
{
    public async Task WriteAsync(AuditLogEntry entry, CancellationToken ct)
    {
        //TO DO : Write in repo
        await Task.Delay(500);
        // await _repo.AddAsync(entry, ct);
    }
}
