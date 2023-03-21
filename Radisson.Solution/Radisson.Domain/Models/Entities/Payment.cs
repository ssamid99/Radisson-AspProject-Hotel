using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Models.Entities
{
    public class Payment : BaseEntity, IPageable
    {
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
        public int Amount { get; set; }
        public string NameonCard { get; set; }
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public int Cvv { get; set; }
    }
}
