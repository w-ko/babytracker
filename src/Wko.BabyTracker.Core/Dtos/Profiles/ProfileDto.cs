namespace Wko.BabyTracker.Core.Dtos.Profiles;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public int AgeInDays { get; set; }
    public decimal AgeInWeeks { get; set; }
    public decimal AgeInMonths { get; set; }
    public decimal AgeInYears { get; set; }
}
