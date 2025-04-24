namespace BackgroundQueueSetup.BackgroundQueue.Interfaces;

public interface IWorkerHandler<T>
{
    Task HandleAsync(T workItem, CancellationToken ct);
}
