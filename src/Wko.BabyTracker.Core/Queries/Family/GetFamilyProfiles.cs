using Microsoft.JSInterop;
using Wko.BabyTracker.Core.Domain.Entities;
using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;

public record GetFamilyProfiles : IQuery<IEnumerable<ProfileDto>>;
public class GetFamilyProfilesHandler: IQueryHandler<GetFamilyProfiles, IEnumerable<ProfileDto>>
{
    private readonly IJSRuntime _jsRuntime;
    public GetFamilyProfilesHandler(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    public async Task<IEnumerable<ProfileDto>> HandleAsync(GetFamilyProfiles query)
    {
        var children = await _jsRuntime.InvokeAsync<Child[]>("childRepository.getChildren");
        if (!children.Any()) return Enumerable.Empty<ProfileDto>();

        return children.Select(child => new ProfileDto
        {
            Id = child.Id,
            FirstName = child.Name,
            AgeInDays = child.Age.Days,
            AgeInWeeks = child.Age.Weeks,
            AgeInMonths = child.Age.Months,
            AgeInYears = child.Age.Years
        });
    }
}
