using Microsoft.AspNetCore.Components;
using Wko.BabyTracker.Core.Dtos.Profiles;
using Wko.BabyTracker.Core.Notification;
using Wko.BabyTracker.Core.Queries.Family;
using Wko.BabyTracker.Features.Shared;

namespace Wko.BabyTracker.Features.Profiles;

public class IndexBase: EventfulComponentBase, INotificationHandler<Notifications.ProfileCreated>
{
    protected IEnumerable<ProfileDto> Profiles { get; set; } = new List<ProfileDto>();
    protected bool HasProfiles => Profiles.Any();
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Profiles = await Dispatcher.QueryAsync(new GetFamilyProfiles());
    }

    protected void NavigateTo(Guid id) => NavigationManager.NavigateTo($"timeline/{id}");
    
    protected void HandleFabClick() => NavigationManager.NavigateTo("profiles/new");
    
    public Task HandleAsync(Notifications.ProfileCreated notification)
    {
        NavigationManager.NavigateTo($"profiles/{notification.Id}");
        return Task.CompletedTask;
    }
}
