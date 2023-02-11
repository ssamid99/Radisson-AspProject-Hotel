using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<RadissonRoleClaim>
    {
        public void Configure(EntityTypeBuilder<RadissonRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
