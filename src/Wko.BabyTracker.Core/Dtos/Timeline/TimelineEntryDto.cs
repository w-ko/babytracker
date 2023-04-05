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
    public MeasureEntryDto Measure { get; set; } = new();
    public NappyEntryDto Nappy { get; set; } = new();
}

public record FeedingEntryDto
{
    public int AmountInMl { get; set; }
    public int AmountInGrams { get; set; }
    public FeedingType Type { get; set; }
}

public record MeasureEntryDto
{
    public int Circumference { get; set; }
    public MeasureType Type { get; set; }
}

public record NappyEntryDto
{
    public NappyType Type { get; set; }
    public PooColour PooColour { get; set; }
}


