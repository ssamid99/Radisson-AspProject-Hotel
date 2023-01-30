using Radisson.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Radisson.Domain.Models.Entities
{
    public class Reservation : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public int? RoomId { get; set; }
        public ICollection<Room> Rooms { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
        public int Price { get; set; }
    }
}
