using MediatR;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Application.AppCode.Services;
using Radisson.Domain.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.ContactPostModule
{
    public class ContactPostPutCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
        public int? AnsweredbyId { get; set; }
        public string Email { get; set; }
        public class ContactPostPutCommandHandler : IRequestHandler<ContactPostPutCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;
            private readonly EmailService emailService;

            public ContactPostPutCommandHandler(RadissonDbContext db, EmailService emailService)
            {
                this.db = db;
                this.emailService = emailService;
            }
            public async Task<JsonResponse> Handle(ContactPostPutCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.ContactPosts.FirstOrDefaultAsync(bg => bg.Id == request.Id && /*bg.AnswerDate == null*/ bg.DeletedDate == null, cancellationToken);

                if (entity == null)
                {
                    return null;
                }
                entity.Answer = request.Answer;
                entity.AnswerDate = DateTime.UtcNow.AddHours(4);
                entity.AnsweredbyId = request.AnsweredbyId;
                entity.Email = request.Email;
                await db.SaveChangesAsync(cancellationToken);
                // await emailService.SendMailAsync(request.Email, "Answer by Admin", request.Answer);
                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };

            }
        }
    }
}
