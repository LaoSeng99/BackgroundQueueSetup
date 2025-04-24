using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using BackgroundQueueSetup.Models;
using BackgroundQueueSetup.Services;

namespace BackgroundQueueSetup.BackgroundQueue.Handlers;

public class AuditLogHandler : IWorkerHandler<AuditLogEntry>
{
    private readonly IAuditLogService _svc;
    public AuditLogHandler(IAuditLogService svc) => _svc = svc;

    public Task HandleAsync(AuditLogEntry entry, CancellationToken ct)
    {
        return _svc.WriteAsync(entry, ct);
    }
}
