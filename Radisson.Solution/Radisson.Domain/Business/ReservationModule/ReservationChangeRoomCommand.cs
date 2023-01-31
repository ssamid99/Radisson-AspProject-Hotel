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
    public class ReservationChangeRoomCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomId { get; set; }
        public class ReservationChangeRoomCommandHandler : IRequestHandler<ReservationChangeRoomCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;

            public ReservationChangeRoomCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<JsonResponse> Handle(ReservationChangeRoomCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations.FirstOrDefaultAsync(re => re.Id == request.Id && re.DeletedDate == null, cancellationToken);

                data.RoomTypeId = request.RoomTypeId;
                data.RoomId = request.RoomId;

                var a = await db.Rooms.FirstOrDefaultAsync(r => r.Id == request.RoomId && r.DeletedDate == null, cancellationToken);
                a.ReservationId = request.Id;
                a.Aviable = false;

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
