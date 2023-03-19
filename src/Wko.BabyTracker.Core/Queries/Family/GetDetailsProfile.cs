using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;


public record GetDetailedProfile(Guid Id) : IQuery<ProfileDto>; 

public class GetDetaildProfileHandler: IQueryHandler<GetDetailedProfile, ProfileDto>
{
    public async Task<ProfileDto> HandleAsync(GetDetailedProfile query)
    {
        return new ProfileDto
        {
            Id = query.Id,
            FirstName = "Sascha"
        };
    }
}
