using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class PeopleinReservation : BaseEntity
    {
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
