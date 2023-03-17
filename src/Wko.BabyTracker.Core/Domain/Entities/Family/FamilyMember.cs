using Wko.BabyTracker.Core.Domain.ValueObjects;

namespace Wko.BabyTracker.Core.Domain.Entities.Family;

public class FamilyMember
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string FamilyName { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public Age Age => new Age(BirthDate);
    public MemberType Type { get; set; }
}
