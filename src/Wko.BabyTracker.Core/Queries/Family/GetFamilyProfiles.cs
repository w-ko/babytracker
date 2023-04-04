using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;

public record GetFamilyProfiles() : IQuery<List<ProfileDto>>;
public class GetFamilyProfilesHandler: IQueryHandler<GetFamilyProfiles, List<ProfileDto>>
{
    public async Task<List<ProfileDto>> HandleAsync(GetFamilyProfiles query)
    {
        return new List<ProfileDto>
        {
            new ProfileDto {Id = 1, FirstName = "John", FamilyName = "Doe"},
            new ProfileDto {Id = 2, FirstName = "Jane", FamilyName = "Doe"}
        };
    }
}
