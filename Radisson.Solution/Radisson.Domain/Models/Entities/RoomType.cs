using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Radisson.Domain.Models.Entities
{
    public class RoomType : BaseEntity, IPageable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string PriceInclude { get; set; }
        public string Slug { get; set; }
        public string ImagePath { get; set; }
    }
}
