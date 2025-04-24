using BackgroundQueueSetup.BackgroundQueue.Handlers;
using BackgroundQueueSetup.BackgroundQueue.HostedServices;
using BackgroundQueueSetup.BackgroundQueue.Implementations;
using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using BackgroundQueueSetup.Models;
using BackgroundQueueSetup.Services;

namespace BackgroundQueueSetup.Commons.Extensions;

public static class DependencyInjector
{
    public static void AddMemoryQueueService(this IServiceCollection services, IConfigurationManager configuration)
    {
        // 1. 注册通用队列实现（ChannelTaskQueue<T>）
        services.AddSingleton(typeof(IBackgroundTaskQueue<>), typeof(ChannelTaskQueue<>));
        //Also can use Rabbit MQ

        // 2. 注册各类型的后台消费服务（使用泛型方法，指定具体类型）
        //    修正错误：不要传入 Type 对象，而是调用 AddHostedService<YourHostedService>()
        services.AddHostedService<QueuedHostedService<EmailMessage>>();
        services.AddHostedService<QueuedHostedService<AuditLogEntry>>();
        // 3. 注册对应的处理器（Handler）
        services.AddScoped<IWorkerHandler<EmailMessage>, EmailHandler>();
        services.AddScoped<IWorkerHandler<AuditLogEntry>, AuditLogHandler>();

        // 4. 注册业务服务与仓储
        services.AddScoped<IAuditLogService, AuditLogService>();
        services.AddScoped<ISampleService, SampleService>();
        //Repo here

    }
}
