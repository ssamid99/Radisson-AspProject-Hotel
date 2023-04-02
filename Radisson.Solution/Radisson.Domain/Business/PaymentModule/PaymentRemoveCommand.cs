using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class PaymentRemoveCommand : IRequest<Payment>
    {
        public int Id { get; set; }
        public class PaymentRemoveCommandHandler : IRequestHandler<PaymentRemoveCommand, Payment>
        {
            private readonly RadissonDbContext db;

            public PaymentRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Payment> Handle(PaymentRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Payments.FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedDate == null, cancellationToken);
                if(data == null)
                {
                    return null;
                }
                data.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
