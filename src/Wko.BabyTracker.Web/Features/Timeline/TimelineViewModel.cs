using Wko.BabyTracker.Core.Dtos.Profiles;
using Wko.BabyTracker.Core.Dtos.Timeline;
using Wko.BabyTracker.Core.Shared.Enums;

namespace Wko.BabyTracker.Web.Features.Timeline;

public class TimelineViewModel
{
    public TimelineViewModel()
    {
        TimelineEntries = new List<TimelineEntryDto>();
        AvailableProfiles = new List<ProfileDto>();
    }

    public bool IsProfileSelected => SelectedProfile != null;
    public bool HasActiveFilter => ActiveFilter != null;
    public TimelineEntryType? ActiveFilter { get; set; }
    
    public IReadOnlyList<TimelineEntryDto> TimelineEntries { get; set; }
    public IReadOnlyList<ProfileDto> AvailableProfiles { get; set; }
    public ProfileDto? SelectedProfile { get; set; }
}
