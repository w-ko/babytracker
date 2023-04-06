using Microsoft.AspNetCore.Components;
using Wko.BabyTracker.Core.Notification;
using Wko.BabyTracker.Core.Services;

namespace Wko.BabyTracker.Features.Shared;

public abstract class EventfulComponentBase: ComponentBase, INotificationHandler, IDisposable
{
    [Inject] protected IDispatcher Dispatcher { get; set; } = default!;
    [Inject] protected INotificationRegistrar NotificationRegistrar { get; set; } = default!;
    
    protected override void OnInitialized() => NotificationRegistrar.Register(this);
    public void Dispose() => NotificationRegistrar.Unregister(this);
}

public abstract class EventfulComponentBase<T>: ComponentBase, INotificationHandler<T> where T : INotification, IDisposable
{
    [Inject] protected IDispatcher Dispatcher { get; set; } = default!;
    [Inject] protected INotificationRegistrar NotificationRegistrar { get; set; } = default!;
    
    protected override void OnInitialized() => NotificationRegistrar.Register(this);
    public async Task HandleAsync(T notification) => await InvokeAsync(StateHasChanged);
    public void Dispose() => NotificationRegistrar.Unregister(this);
}
