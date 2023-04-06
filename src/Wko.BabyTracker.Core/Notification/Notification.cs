namespace Wko.BabyTracker.Core.Notification;

public static class Notification
{
    public record ProfileCreated(Guid Id, string Name): INotification;
    public record TimelineEntryCreated(Guid Id, Guid ChildId): INotification;
}
