using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using BackgroundQueueSetup.Models;

namespace BackgroundQueueSetup.Services;

public interface ISampleService
{
    Task SendWithLog(EmailMessage entry);
}
public class SampleService(
    IBackgroundTaskQueue<EmailMessage> emailQueue,
    IBackgroundTaskQueue<AuditLogEntry> auditQueue
    ) : ISampleService
{
    public async Task SendWithLog(EmailMessage entry)
    {
        await auditQueue.EnqueueAsync(new AuditLogEntry()
        {
            UserId = "12",
            Action = "hi",
            Details = "Haha",
            Timestamp = DateTime.Now
        });
        await emailQueue.EnqueueAsync(entry);
    }
}
