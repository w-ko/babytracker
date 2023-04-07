using System.ComponentModel.DataAnnotations;
using Wko.BabyTracker.Core.Commands;

namespace Wko.BabyTracker.Features.Profiles;

public class NewProfileViewModel: IValidatableObject
{
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset? BirthDate { get; set; } = DateTimeOffset.Now;
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("Name is required", new[] {nameof(Name)});
        }
    }
    
    public Commands.CreateProfile ToCommand() => new(Name, BirthDate);
}
