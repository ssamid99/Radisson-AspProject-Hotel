using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonUserEntityTypeConfiguration : IEntityTypeConfiguration<RadissonUser>
    {
        public void Configure(EntityTypeBuilder<RadissonUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}
