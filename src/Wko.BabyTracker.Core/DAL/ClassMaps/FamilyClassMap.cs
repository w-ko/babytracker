using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wko.BabyTracker.Core.Domain.Entities.Family;

namespace Wko.BabyTracker.Core.DAL.ClassMaps;

public class FamilyClassMap: IEntityTypeConfiguration<Family>
{
    public void Configure(EntityTypeBuilder<Family> builder)
    {
    }
}

public class FamilyMemberClassMap: IEntityTypeConfiguration<FamilyMember>
{
    public void Configure(EntityTypeBuilder<FamilyMember> builder)
    {
    }
}
