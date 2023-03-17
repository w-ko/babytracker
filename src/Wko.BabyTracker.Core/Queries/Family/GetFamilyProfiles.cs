using Wko.BabyTracker.Core.Dtos.Profiles;

namespace Wko.BabyTracker.Core.Queries.Family;

public record GetFamilyProfiles() : IQuery<List<ProfileDto>>;
public record GetDetailedProfile(Guid Id) : IQuery<ProfileDto>; 
