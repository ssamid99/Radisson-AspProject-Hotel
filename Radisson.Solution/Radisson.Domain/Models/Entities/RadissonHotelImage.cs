using Radisson.Domain.AppCode.Infrastructure;

namespace Radisson.Domain.Models.Entities
{
    public class RadissonHotelImage : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int RadissonHotelsId { get; set; }
        public virtual RadissonHotel RadissonHotels { get; set; }
    }
}
