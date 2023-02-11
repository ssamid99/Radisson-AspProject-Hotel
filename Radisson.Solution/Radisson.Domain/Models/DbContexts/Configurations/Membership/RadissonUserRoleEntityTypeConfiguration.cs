using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<RadissonUserRole>
    {
        public void Configure(EntityTypeBuilder<RadissonUserRole> builder)
        {
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
