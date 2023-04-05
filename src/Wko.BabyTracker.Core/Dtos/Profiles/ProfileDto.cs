namespace Wko.BabyTracker.Core.Dtos.Profiles;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string FamilyName { get; set; } = string.Empty;
}
