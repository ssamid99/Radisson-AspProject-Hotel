using MediatR;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.AppCode.Infrastructure;
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
    public class ReservationConfirmCommand : IRequest<Reservation>
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public class ReservationConfirmCommandHandler : IRequestHandler<ReservationConfirmCommand, Reservation>
        {
            private readonly RadissonDbContext db;

            public ReservationConfirmCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Reservation> Handle(ReservationConfirmCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations.FirstOrDefaultAsync(re => re.Id == request.Id && re.DeletedDate == null, cancellationToken);

                data.RoomId = request.RoomId;

                var a = await db.Rooms.FirstOrDefaultAsync(r => r.Id == request.RoomId && r.ReservationId == null && r.Aviable == true && r.DeletedDate == null, cancellationToken);
                a.ReservationId = request.Id;
                a.Aviable = false;
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }
        }
    }
}
