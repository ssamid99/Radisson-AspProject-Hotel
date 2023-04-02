using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Radisson.Domain.Models.Entities
{
    public class Reservation : BaseEntity, IPageable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int? RoomId { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public int RoomTypeId { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
        public int Price { get; set; }
        public virtual ICollection<PeopleinReservation> PeopleCloud { get; set; }
    }
}
