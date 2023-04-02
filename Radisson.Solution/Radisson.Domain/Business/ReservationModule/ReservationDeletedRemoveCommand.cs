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

namespace Radisson.Domain.Business.ReservationModule
{
    public class ReservationDeletedRemoveCommand : IRequest<Reservation>
    {
        public int Id { get; set; }
        public class ReservationDeletedRemoveCommandHandler : IRequestHandler<ReservationDeletedRemoveCommand, Reservation>
        {
            private readonly RadissonDbContext db;

            public ReservationDeletedRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Reservation> Handle(ReservationDeletedRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate != null, cancellationToken);
                if (data == null)
                {
                    return null;
                }
                db.Reservations.Remove(data);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
