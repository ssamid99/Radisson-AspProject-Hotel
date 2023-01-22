using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.Domain.Models.DbContexts
{
    public partial class RadissonDbContext
    {
        public DbSet<RadissonRole> RadissonRoles { get; set; }
        public DbSet<RadissonRoleClaim> RadissonRoleClaims { get; set; }
        public DbSet<RadissonUser> RadissonUsers { get; set; }
        public DbSet<RadissonUserClaim> RadissonUserClaims { get; set; }
        public DbSet<RadissonUserLogin> RadissonUserLogins { get; set; }
        public DbSet<RadissonUserRole> RadissonUserRoles { get; set; }
        public DbSet<RadissonUserToken> RadissonUserTokens { get; set; }
    }
}
