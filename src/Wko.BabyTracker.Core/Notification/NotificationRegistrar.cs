namespace Wko.BabyTracker.Core.Notification;

public interface INotificationRegistrar
{
    public void Register(INotificationHandler handler);
    public void Unregister(INotificationHandler handler);
    INotificationHandler<TNotification> GetHandler<TNotification>(TNotification notification) where TNotification : INotification;
}

public class NotificationRegistrar: INotificationRegistrar
{
    private readonly ISet<INotificationHandler> _notificationHandlers;
    public NotificationRegistrar() => _notificationHandlers = new HashSet<INotificationHandler>();

    public void Register(INotificationHandler handler) => _notificationHandlers.Add(handler);
    public void Unregister(INotificationHandler handler) => _notificationHandlers.Remove(handler);
    
    public INotificationHandler<TNotification> GetHandler<TNotification>(TNotification notification) where TNotification : INotification
    {
        var handlerType = typeof(INotificationHandler<>).MakeGenericType(typeof(TNotification));
        var handler = _notificationHandlers.FirstOrDefault(h => h.GetType().GetInterfaces().Contains(handlerType));
        if (handler == null)
        {
            throw new InvalidOperationException($"No handler registered for notification {typeof(TNotification).Name}");
        }
        
        return (INotificationHandler<TNotification>) handler;
    }
}
