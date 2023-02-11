using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.DbContexts.Configurations
{
    public class RoomTypeEntityTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(c => c.Name)
                .IsRequired();
            builder.Property(c => c.Price)
                .IsRequired();
            builder.Property(c => c.PriceInclude)
                .IsRequired();
            builder.Property(c => c.Slug)
                .IsUnicode(false)
                .HasMaxLength(900)
                .IsRequired();
            builder.HasIndex(p => p.Slug)
                .IsUnique();
            builder.Property(c => c.ImagePath)
                .IsRequired();
        }
    }
}
