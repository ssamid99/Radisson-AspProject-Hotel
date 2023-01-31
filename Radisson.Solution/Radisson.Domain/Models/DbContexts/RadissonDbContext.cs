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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var asm = typeof(RadissonDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(asm);

            modelBuilder.Entity<RadissonUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });
            modelBuilder.Entity<RadissonRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });
            modelBuilder.Entity<RadissonUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });
            modelBuilder.Entity<RadissonUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });
            modelBuilder.Entity<RadissonRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });
            modelBuilder.Entity<RadissonUserRole>(e =>
            {
                e.ToTable("UserRoles", "Membership");
            });
            modelBuilder.Entity<RadissonUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });
        }

        
    }
}
