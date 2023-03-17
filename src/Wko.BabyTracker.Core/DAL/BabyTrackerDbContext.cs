using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wko.BabyTracker.Core.DAL.ClassMaps;
using Wko.BabyTracker.Core.Domain.Entities.Family;

namespace Wko.BabyTracker.Core.DAL;

public class BabyTrackerDbContext : IdentityDbContext
{
    public BabyTrackerDbContext(DbContextOptions<BabyTrackerDbContext> options) : base(options) { }

    public DbSet<Family> Families { get; set; } = default!;
    public DbSet<FamilyMember> FamilyMembers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(FamilyClassMap).Assembly);
        base.OnModelCreating(builder);
    }
}
