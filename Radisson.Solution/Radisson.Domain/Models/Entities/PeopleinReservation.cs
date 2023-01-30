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
        public int ReservationId { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public int PeoplesId { get; set; }
        public ICollection<People> Peoples { get; set; }
    }
}
