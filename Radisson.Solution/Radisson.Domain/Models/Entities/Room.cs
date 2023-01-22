using Radisson.Domain.AppCode.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Radisson.Domain.Models.Entities
{
    public class Room : BaseEntity
    {
        [Required]
        public int Number { get; set; }
        [DefaultValue(true)]
        public bool Aviable { get; set; }
        public int? ReservationId { get; set; }
        public Reservation Resevation { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        public RoomType RoomTypes { get; set; }
    }
}
