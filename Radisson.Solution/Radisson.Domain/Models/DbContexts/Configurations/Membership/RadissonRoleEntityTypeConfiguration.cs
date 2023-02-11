using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonRoleEntityTypeConfiguration : IEntityTypeConfiguration<RadissonRole>
    {
        public void Configure(EntityTypeBuilder<RadissonRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}
