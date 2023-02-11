using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Models.DbContexts.Configurations
{
    public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(c => c.Surname)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.CheckIn)
                .IsRequired();
            builder.Property(c => c.CheckOut)
                .IsRequired();
            builder.Property(c => c.RoomTypeId)
                .IsRequired();
        }
    }
}
