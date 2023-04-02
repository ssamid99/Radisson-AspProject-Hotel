using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Radisson.Application.AppCode.Extensions;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.ContactPostModule
{
    public class ContactPostPostCommand : IRequest<ContactPost>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public int? AnsweredbyId { get; set; }
        public class ContactPostPostCommandHandler : IRequestHandler<ContactPostPostCommand, ContactPost>
        {
            private readonly RadissonDbContext db;
            private readonly IActionContextAccessor ctx;

            public ContactPostPostCommandHandler(RadissonDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<ContactPost> Handle(ContactPostPostCommand request, CancellationToken cancellationToken)
            {
                var data = new ContactPost();
                data.Name = request.Name;
                data.Surname = request.Surname;
                data.Email = request.Email;
                data.Phone = request.Phone;
                data.Message = request.Message;
                data.CreatedByUserId = ctx.GetCurrentUserId();
                await db.ContactPosts.AddAsync(data, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
