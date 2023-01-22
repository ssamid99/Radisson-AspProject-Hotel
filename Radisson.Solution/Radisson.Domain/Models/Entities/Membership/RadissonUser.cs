using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Radisson.Domain.Models.Entities.Membership
{
    public class RadissonUser : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
