using Radisson.Domain.AppCode.Infrastructure;

namespace Radisson.Domain.Models.Entities
{
    public class PeopleinReservation : BaseEntity
    {
        public int PeopleFirst { get; set; }
        public int PeopleSecond { get; set; }
        public int PeopleThird { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public virtual People People { get; set; }
    }
}
