using Wko.BabyTracker.Core.Queries.Family;
using Wko.BabyTracker.Core.Queries.Timeline;
using Wko.BabyTracker.Core.Services;

namespace Wko.BabyTracker.Web.Features.Timeline;

public class TimelineViewModelBuilder
{
    private readonly Guid? _childId;

    private TimelineViewModelBuilder(Guid? childId) => _childId = childId;
    public static TimelineViewModelBuilder ForChildId(Guid? id) => new(id);

    public async Task<TimelineViewModel> Build(IDispatcher dispatcher)
    {
        if (_childId == null) return await CreateEmptyTimelineViewModel(dispatcher);

        var selectedProfile = await dispatcher.QueryAsync(new GetDetailedProfile(_childId!.Value));
        var pagedResult = await dispatcher.QueryAsync(new GetTimeLineEntries(_childId.Value));
        return new TimelineViewModel
        {
            SelectedProfile = selectedProfile,
            TimelineEntries = pagedResult.Data
        };
    }

    private async Task<TimelineViewModel> CreateEmptyTimelineViewModel(IDispatcher dispatcher)
    {
        var availableProfiles = await dispatcher.QueryAsync(new GetFamilyProfiles());
        return new TimelineViewModel { AvailableProfiles = availableProfiles };
    }
}
