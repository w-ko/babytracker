using Wko.BabyTracker.Core.Shared.Enums;
using Wko.BabyTracker.Globals;

namespace Wko.BabyTracker.Features.Timeline;

public static class TimelineTitleFactory
{
    public static string CreateMeasurementTitle(MeasureType measureType, string firstName)
    {
        return measureType switch
        {
            MeasureType.Weight => string.Format(ApplicationLabels.Timeline_Title_Measure_Weight, firstName),
            MeasureType.Height => string.Format(ApplicationLabels.Timeline_Title_Measure_Size, firstName),
            MeasureType.HeadCircumference => string.Format(ApplicationLabels.Timeline_Title_Measure_Circumference, firstName),
            MeasureType.Temperature => string.Format(ApplicationLabels.Timeline_Title_Measure_Temperature, firstName),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static string CreateFeedingTitle(string firstName) => string.Format(ApplicationLabels.Timeline_Title_Feeding, firstName);
    public static string CreateSleepingTitle(string firstName) => string.Format(ApplicationLabels.Timeline_Title_Sleep, firstName);
    public static string CreateMilestoneTitle(string firstName) => string.Format(ApplicationLabels.Timeline_Title_Milestone, firstName);
    public static string CreateNappyChangeTitle(string firstName) => string.Format(ApplicationLabels.Timeline_Title_NappyChange, firstName);
}
