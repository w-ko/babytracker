using Wko.BabyTracker.Core.Shared.Enums;

namespace Wko.BabyTracker.Core.Dtos.Timeline;

public class TimelineEntryDto
{
    public Guid Id { get; set; }
    public Guid ChildId { get; set; }
    public TimelineEntryType Type { get; set; }
    public string Body { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? EndDate { get; set; }

    public FeedingEntryDto Feeding { get; set; } = new();
    public SleepEntryDto Sleep { get; set; } = new();
}

public class FeedingEntryDto
{
    public int AmountInMl { get; set; }
    public FeedingType Type { get; set; }
}

public class SleepEntryDto
{
    
}

