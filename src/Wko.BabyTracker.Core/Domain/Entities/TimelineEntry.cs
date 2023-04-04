using Wko.BabyTracker.Core.Shared.Enums;

namespace Wko.BabyTracker.Core.Domain.Entities;

public class TimelineEntry
{
    public int Id { get; set; }
    public int ChildId { get; set; }
    public TimelineEntryType Type { get; set; }
    public string Body { get; set; } = string.Empty;
    public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? End { get; set; }

    public FeedingEntry Feeding { get; set; } = new();
    public MeasureEntry Measure { get; set; } = new();
    public NappyEntry Nappy { get; set; } = new();
}


public record FeedingEntry
{
    public int AmountInMl { get; set; }
    public int AmountInGrams { get; set; }
    public FeedingType Type { get; set; }
}

public record MeasureEntry
{
    public int Circumference { get; set; }
    public MeasureType Type { get; set; }
}

public record NappyEntry
{
    public NappyType Type { get; set; }
    public PooColour PooColour { get; set; }
}
