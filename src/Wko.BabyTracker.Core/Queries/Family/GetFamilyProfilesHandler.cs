using Wko.BabyTracker.Core.DAL;
using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;

public class GetFamilyProfilesHandler: IQueryHandler<GetFamilyProfiles, List<ProfileDto>>
{
    private readonly BabyTrackerDbContext _dbContext;

    public GetFamilyProfilesHandler(BabyTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ProfileDto>> HandleAsync(GetFamilyProfiles query)
    {
        return new List<ProfileDto>
        {
            new ProfileDto {Id = Guid.NewGuid(), FirstName = "John", FamilyName = "Doe"},
            new ProfileDto {Id = Guid.NewGuid(), FirstName = "Jane", FamilyName = "Doe"}
        };
    }
}
