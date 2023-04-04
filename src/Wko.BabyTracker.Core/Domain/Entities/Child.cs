using Wko.BabyTracker.Core.Domain.ValueObjects;

namespace Wko.BabyTracker.Core.Domain.Entities;

public class Child
{
    public int Id { get; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset? BirthDate { get; set; } = DateTimeOffset.Now;
    public Age Age => new Age(BirthDate);
}
