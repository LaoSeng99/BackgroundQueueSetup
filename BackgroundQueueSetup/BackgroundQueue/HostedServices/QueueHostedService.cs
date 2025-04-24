using BackgroundQueueSetup.BackgroundQueue.Interfaces;

namespace BackgroundQueueSetup.BackgroundQueue.HostedServices;

public class QueuedHostedService<T> : BackgroundService
{
    private readonly IBackgroundTaskQueue<T> _queue;
    private readonly IServiceScopeFactory _scopeFactory;
    public QueuedHostedService(IBackgroundTaskQueue<T> queue,
        IServiceScopeFactory scopeFactory)
    {
        _queue = queue;
        _scopeFactory = scopeFactory;
    }

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
