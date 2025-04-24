using BackgroundQueueSetup.BackgroundQueue.Interfaces;

namespace BackgroundQueueSetup.BackgroundQueue.HostedServices;

public class QueuedHostedService<T>(
    IBackgroundTaskQueue<T> _queue,
    IServiceScopeFactory _scopeFactory
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var item = await _queue.DequeueAsync(stoppingToken);
            using var scope = _scopeFactory.CreateScope();
            var handler = scope.ServiceProvider
                .GetRequiredService<IWorkerHandler<T>>();
            await handler.HandleAsync(item, stoppingToken);
        }
    }
}
