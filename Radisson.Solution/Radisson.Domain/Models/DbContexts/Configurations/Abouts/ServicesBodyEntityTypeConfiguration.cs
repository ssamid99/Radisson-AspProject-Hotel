using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Models.DbContexts.Configurations.Abouts
{
    public class ServicesBodyEntityTypeConfiguration : IEntityTypeConfiguration<ServicesBody>
    {
        public void Configure(EntityTypeBuilder<ServicesBody> builder)
        {
            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(c => c.Title)
                .IsRequired();
            builder.Property(c => c.Text)
                .IsRequired();
            builder.Property(c => c.ServicesHeaderId)
                .IsRequired();
            builder.Property(c => c.ImagePath)
                            .IsRequired();
        }
    }
}
