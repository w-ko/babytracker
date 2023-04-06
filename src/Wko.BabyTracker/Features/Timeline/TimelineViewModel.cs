using Wko.BabyTracker.Core.Dtos.Profiles;
using Wko.BabyTracker.Core.Dtos.Timeline;
using Wko.BabyTracker.Core.Shared.Enums;
using Wko.BabyTracker.Globals;

namespace Wko.BabyTracker.Features.Timeline;

public class TimelineViewModel
{
    private readonly IEnumerable<TimelineEntryDto> _timelineEntries = new List<TimelineEntryDto>();

    public TimelineViewModel()
    {
        TimelineEntries = new List<TimelineEntryDto>();
        AvailableProfiles = new List<ProfileDto>();
    }

    public bool IsProfileSelected => SelectedProfile != null;
    public bool HasActiveFilter => ActiveFilter != null;
    public TimelineEntryType? ActiveFilter { get; set; }

    public IEnumerable<TimelineEntryDto> TimelineEntries
    {
        get => _timelineEntries.OrderByDescending(entry => entry.StartDate).ToList();
        init => _timelineEntries = value;
    }

    public IEnumerable<ProfileDto> AvailableProfiles { get; set; }
    public ProfileDto? SelectedProfile { get; set; }
    public bool HasTimelineEntries => IsProfileSelected && TimelineEntries.Any();
    
    public string GetEntryTitle(TimelineEntryDto entryDto)
    {
        if (SelectedProfile == null) return ApplicationLabels.Timeline_Title_Default;

        return entryDto.Type switch
        {
            TimelineEntryType.Feeding => TimelineTitleFactory.CreateFeedingTitle(SelectedProfile!.FirstName),
            TimelineEntryType.Sleep => TimelineTitleFactory.CreateSleepingTitle(SelectedProfile!.FirstName),
            TimelineEntryType.Measure => TimelineTitleFactory.CreateMeasurementTitle(entryDto.Measure.Type, SelectedProfile!.FirstName),
            TimelineEntryType.Milestone => TimelineTitleFactory.CreateMilestoneTitle(SelectedProfile!.FirstName),
            TimelineEntryType.Nappy => TimelineTitleFactory.CreateNappyChangeTitle(SelectedProfile!.FirstName),
            _ => ApplicationLabels.Timeline_Title_Default
        };
    }
    
    
    public string GetEntryBody(TimelineEntryDto entry)
    {

        return entry.Body;
        // return entry.Type switch
        // {
        //     TimelineEntryType.Feeding => string.Format(ApplicationLabels.Timeline_Body_Feeding, entry.Feeding.AmountInMl, entry.Feeding.Type),
        //     TimelineEntryType.Sleep => string.Format(ApplicationLabels.Timeline_Body_Sleep, entry.StartDate, entry.EndDate),
        //     TimelineEntryType.Measure => string.Format(ApplicationLabels.Timeline_Body_Measure_Circumference, entry.Measure.Circumference),
        //     TimelineEntryType.Milestone => string.Format(ApplicationLabels.Timeline_Body_Milestone, entry.Milestone.Name),
        //     TimelineEntryType.Nappy => string.Format(ApplicationLabels.Timeline_Body_NappyChange, entry.Nappy.Type),
        //     _ => ApplicationLabels.Timeline_Title_Default
        // };
    }
}
