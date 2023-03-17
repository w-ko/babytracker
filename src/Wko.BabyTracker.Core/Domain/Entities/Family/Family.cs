namespace Wko.BabyTracker.Core.Domain.Entities.Family;

public class Family
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<FamilyMember> Members { get; set; } = new();
}
