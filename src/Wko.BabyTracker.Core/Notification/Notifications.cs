namespace Wko.BabyTracker.Core.Notification;

public static class Notifications
{
    public record ProfileCreated(Guid Id, string Name): INotification;
    public record TimelineEntryCreated(Guid Id, Guid ChildId): INotification;

    public record Error(string Message) : INotification;
}
