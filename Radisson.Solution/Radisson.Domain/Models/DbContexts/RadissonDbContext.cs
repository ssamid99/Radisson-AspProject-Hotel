using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Models.Entities;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DbContexts
{
    public partial class RadissonDbContext : IdentityDbContext<RadissonUser, RadissonRole, int, RadissonUserClaim, RadissonUserRole, RadissonUserLogin, RadissonRoleClaim, RadissonUserToken>
    {
        public RadissonDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<PeopleinReservation> ReservePeopleCloud { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<RadissonHotel> RadissonHotels { get; set; }
        public DbSet<RadissonHotelImage> RadissonHotelImages { get; set; }
        public DbSet<ServicesHeader> ServicesHeaders { get; set; }
        public DbSet<ServicesBody> ServicesBodies { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(RadissonDbContext).Assembly);
        }
    }
}
