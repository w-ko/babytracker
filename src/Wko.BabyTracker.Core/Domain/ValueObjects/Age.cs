using Wko.BabyTracker.Core.Shared.Consts;

namespace Wko.BabyTracker.Core.Domain.ValueObjects;

public record Age
{
    private readonly DateTimeOffset? _birthDay;

    public Age(DateTimeOffset? birthDay)
    {
        _birthDay = birthDay;
    }

    public int Days
    {
        get
        {
            var timeSpan = (DateTimeOffset.Now - _birthDay);
            if (!timeSpan.HasValue) return Calendar.DefaultDays;
            return (int)timeSpan.Value.TotalDays;
        }
    }

    public decimal Weeks
    {
        get
        {
            var timeSpan = (DateTimeOffset.Now - _birthDay);
            if (!timeSpan.HasValue) return Calendar.DefaultWeeks;
            return (decimal)timeSpan.Value.TotalDays / Calendar.DaysInWeek;
        }
    }

    public decimal Months
    {
        get
        {
            var timeSpan = (DateTimeOffset.Now - _birthDay);
            if (!timeSpan.HasValue) return Calendar.DefaultMonths;
            return (decimal)timeSpan.Value.TotalDays / Calendar.Months;
        }
    }

    public decimal Years
    {
        get
        {
            var timeSpan = (DateTimeOffset.Now - _birthDay);
            if (!timeSpan.HasValue) return Calendar.DefaultMonths;
            return (decimal)timeSpan.Value.TotalDays / Calendar.Days;
        }
    }
}
