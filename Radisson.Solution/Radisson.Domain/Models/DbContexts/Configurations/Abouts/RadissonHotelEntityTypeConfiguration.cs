using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.DbContexts.Configurations.Abouts
{
    public class RadissonHotelEntityTypeConfiguration : IEntityTypeConfiguration<RadissonHotel>
    {
        public void Configure(EntityTypeBuilder<RadissonHotel> builder)
        {
            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(c => c.Title)
                .IsRequired();
            builder.Property(c => c.Text)
                .IsRequired();
            builder.Property(c => c.FullText)
                .IsRequired();
            builder.Property(c => c.ImagePath)
                .IsRequired();
        }
    }
}
