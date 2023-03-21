using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Radisson.Application.AppCode.Extensions;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.PaymentModule
{
    public class PaymentPostCommand : IRequest<JsonResponse>
    {
        public int ReservationId { get; set; }
        public string NameonCard { get; set; }
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public int Cvv { get; set; }
        public class PaymentPostCommandHandler : IRequestHandler<PaymentPostCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;
            private readonly IActionContextAccessor ctx;

            public PaymentPostCommandHandler(RadissonDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<JsonResponse> Handle(PaymentPostCommand request, CancellationToken cancellationToken)
            {
                var entity = new Payment();
                entity.ReservationId = request.ReservationId;
                entity.NameonCard = request.NameonCard;
                entity.Number = request.Number;
                entity.Expiration = request.Expiration;
                entity.Cvv = request.Cvv;
                entity.CreatedByUserId = ctx.GetCurrentUserId();
                await db.Payments.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }
        }
    }
}
