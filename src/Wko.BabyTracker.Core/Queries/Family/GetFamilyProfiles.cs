using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;

public record GetFamilyProfiles() : IQuery<List<ProfileDto>>;
public class GetFamilyProfilesHandler: IQueryHandler<GetFamilyProfiles, List<ProfileDto>>
{
    public async Task<List<ProfileDto>> HandleAsync(GetFamilyProfiles query)
    {
        return new List<ProfileDto>
        {
            new ProfileDto {Id = Guid.NewGuid(), FirstName = "John", FamilyName = "Doe"},
            new ProfileDto {Id = Guid.NewGuid(), FirstName = "Jane", FamilyName = "Doe"}
        };
    }
}
