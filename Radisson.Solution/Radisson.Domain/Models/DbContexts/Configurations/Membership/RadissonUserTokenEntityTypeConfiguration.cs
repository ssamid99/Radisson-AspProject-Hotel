using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<RadissonUserToken>
    {
        public void Configure(EntityTypeBuilder<RadissonUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
