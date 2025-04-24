namespace BackgroundQueueSetup.BackgroundQueue.Interfaces;

public interface IBackgroundTaskQueue<T>
{
    ValueTask EnqueueAsync(T workItem);
    ValueTask<T> DequeueAsync(CancellationToken ct);
}
