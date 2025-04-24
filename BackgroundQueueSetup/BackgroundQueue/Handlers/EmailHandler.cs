using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using BackgroundQueueSetup.Models;

namespace BackgroundQueueSetup.BackgroundQueue.Handlers;

public class EmailHandler : IWorkerHandler<EmailMessage>
{
    public Task HandleAsync(EmailMessage msg, CancellationToken ct)
    {
        // Use email service to send real email
        Console.WriteLine($"Sending email to {msg.To}: {msg.Subject}");
        return Task.CompletedTask;
    }
}
