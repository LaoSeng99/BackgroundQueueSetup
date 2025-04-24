using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using BackgroundQueueSetup.Models;
using BackgroundQueueSetup.Services;

namespace BackgroundQueueSetup.BackgroundQueue.Handlers;

public class AuditLogHandler(
    IAuditLogService _svc
    ) : IWorkerHandler<AuditLogEntry>
{


    public Task HandleAsync(AuditLogEntry entry, CancellationToken ct)
    {
        return _svc.WriteAsync(entry, ct);
    }
}
