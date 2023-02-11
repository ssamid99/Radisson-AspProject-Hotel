using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Models.DbContexts.Configurations
{
    public class SubscribeEntityTypeConfiguration : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(c => c.Email)
                .HasMaxLength(90)
                .IsRequired();
        }
    }
}
