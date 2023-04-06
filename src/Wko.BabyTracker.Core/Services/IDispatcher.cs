using Wko.BabyTracker.Core.Commands;
using Wko.BabyTracker.Core.Notification;
using Wko.BabyTracker.Core.Queries;

namespace Wko.BabyTracker.Core.Services;

public interface IDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    Task NotifyAsync<TNotification>(TNotification notification) where TNotification: INotification;
}
