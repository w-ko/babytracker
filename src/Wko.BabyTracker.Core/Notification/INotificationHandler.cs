namespace Wko.BabyTracker.Core.Notification;


public interface INotificationHandler
{
    // Marker interface
}

public interface INotificationHandler<in TNotification>: INotificationHandler where TNotification : INotification
{
    Task HandleAsync(TNotification notification);
}
