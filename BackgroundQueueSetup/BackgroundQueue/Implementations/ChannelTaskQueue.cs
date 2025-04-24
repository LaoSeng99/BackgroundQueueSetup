using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using System.Threading.Channels;

namespace BackgroundQueueSetup.BackgroundQueue.Implementations;

public class ChannelTaskQueue<T> : IBackgroundTaskQueue<T>
{
    private readonly Channel<T> _channel = Channel.CreateUnbounded<T>();
    public async ValueTask EnqueueAsync(T workItem)
        => await _channel.Writer.WriteAsync(workItem);
    public async ValueTask<T> DequeueAsync(CancellationToken ct)
        => await _channel.Reader.ReadAsync(ct);
}
