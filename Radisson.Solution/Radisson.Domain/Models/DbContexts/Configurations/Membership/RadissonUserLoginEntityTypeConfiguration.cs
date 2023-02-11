using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DataContexts.Configurations.Membership
{
    public class RadissonUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<RadissonUserLogin>
    {
        public void Configure(EntityTypeBuilder<RadissonUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
