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
    public class ReservationRemoveCommand : IRequest<Reservation>
    {
        public int Id { get; set; }
        public class ReservationRemoveCommandHandler : IRequestHandler<ReservationRemoveCommand, Reservation>
        {
            private readonly RadissonDbContext db;

            public ReservationRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Reservation> Handle(ReservationRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate == null, cancellationToken);
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
