using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Extensions;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Application.AppCode.Services;
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
    public class ContactPostPutCommand : IRequest<ContactPost>
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public class ContactPostPutCommandHandler : IRequestHandler<ContactPostPutCommand, ContactPost>
        {
            private readonly RadissonDbContext db;
            private readonly EmailService emailService;
            private readonly IActionContextAccessor ctx;

            public ContactPostPutCommandHandler(RadissonDbContext db, EmailService emailService, IActionContextAccessor ctx)
            {
                this.db = db;
                this.emailService = emailService;
                this.ctx = ctx;
            }
            public async Task<ContactPost> Handle(ContactPostPutCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.ContactPosts.FirstOrDefaultAsync(bg => bg.Id == request.Id && /*bg.AnswerDate == null*/ bg.DeletedDate == null, cancellationToken);

                if (entity == null)
                {
                    return null;
                }
                entity.Answer = request.Answer;
                entity.AnswerDate = DateTime.UtcNow.AddHours(4);
                entity.AnsweredbyId = ctx.GetCurrentUserId();
                await db.SaveChangesAsync(cancellationToken);
                await emailService.SendMailAsync(entity.Email, "Answer by Admin", request.Answer);
                return entity;

            }
        }
    }
}
