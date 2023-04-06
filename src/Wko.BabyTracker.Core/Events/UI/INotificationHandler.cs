namespace Wko.BabyTracker.Core.Events.UI;

public interface INotificationHandler<in TNotification> where TNotification : INotification
{
    Task HandleAsync(TNotification notification);
}
