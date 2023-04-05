using System.Text.Json.Serialization;
using Wko.BabyTracker.Core.Domain.ValueObjects;

namespace Wko.BabyTracker.Core.Domain.Entities;

public class Child
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset? BirthDate { get; set; } = DateTimeOffset.Now;
    [JsonIgnore] public Age Age => new Age(BirthDate);
}
