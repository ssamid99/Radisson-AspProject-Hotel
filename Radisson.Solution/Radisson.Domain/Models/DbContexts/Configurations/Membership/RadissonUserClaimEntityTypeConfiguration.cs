using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<RadissonUserClaim>
    {
        public void Configure(EntityTypeBuilder<RadissonUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
