using Wko.BabyTracker.Core.Queries.Family;
using Wko.BabyTracker.Core.Queries.Timeline;
using Wko.BabyTracker.Core.Services;

namespace Wko.BabyTracker.Features.Timeline;

public class TimelineViewModelBuilder
{
    private readonly int? _childId;

    private TimelineViewModelBuilder(int? childId) => _childId = childId;
    public static TimelineViewModelBuilder ForChildId(int? id) => new(id);

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
