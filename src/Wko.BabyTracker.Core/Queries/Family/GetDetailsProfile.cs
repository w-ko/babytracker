using Microsoft.JSInterop;
using Wko.BabyTracker.Core.Domain.Entities;
using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;

public record GetDetailedProfile(Guid Id) : IQuery<ProfileDto?>; 

public class GetDetailedProfileHandler: IQueryHandler<GetDetailedProfile, ProfileDto?>
{
    private readonly IJSRuntime _jsRuntime;
    public GetDetailedProfileHandler(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    public async Task<ProfileDto?> HandleAsync(GetDetailedProfile query)
    {
        var child = await _jsRuntime.InvokeAsync<Child?>("childRepository.getChild", query.Id);
        if (child == null) return null;

        return new ProfileDto
        {
            Id = query.Id,
            FirstName = child.Name,
            AgeInDays = child.Age.Days,
            AgeInWeeks = child.Age.Weeks,
            AgeInMonths = child.Age.Months,
            AgeInYears = child.Age.Years
        };
    }
}
