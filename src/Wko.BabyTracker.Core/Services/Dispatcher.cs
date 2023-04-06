using Microsoft.Extensions.DependencyInjection;
using Wko.BabyTracker.Core.Commands;
using Wko.BabyTracker.Core.Notification;
using Wko.BabyTracker.Core.Queries;

namespace Wko.BabyTracker.Core.Services;

public sealed class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var queryType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(queryType);

        var method = handler.GetType().GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
        return await (Task<TResult>) method!.Invoke(handler, new[] { query });
    }

    public async Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command);
    }

    public async Task NotifyAsync<TNotification>(TNotification notification) where TNotification : INotification
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var handler = scope.ServiceProvider.GetRequiredService<INotificationRegistrar>().GetHandler(notification);

        await handler.HandleAsync(notification);
    }
}
