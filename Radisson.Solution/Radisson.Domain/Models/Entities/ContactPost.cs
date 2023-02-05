using Radisson.Domain.AppCode.Infrastructure;
using System;

namespace Radisson.Domain.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public int? AnsweredbyId { get; set; }
    }
}
