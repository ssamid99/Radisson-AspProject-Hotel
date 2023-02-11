using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Models.DbContexts.Configurations.Abouts
{
    public class ServicesHeaderEntityTypeConfiguration : IEntityTypeConfiguration<ServicesHeader>
    {
        public void Configure(EntityTypeBuilder<ServicesHeader> builder)
        {
            builder.HasIndex(b => b.Id);
            builder.Property(b=>b.Id)
                .UseIdentityColumn(1,1);
            builder.Property(b => b.Title)
                .IsRequired();
        }
    }
}
