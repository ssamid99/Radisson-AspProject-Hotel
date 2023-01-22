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

namespace Radisson.Domain.Business.RoomModule
{
    public class RoomPutCommand : IRequest<Room>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Aviable { get; set; }
        public int? ReservationId { get; set; }
        public int RoomTypeId { get; set; }
        public class RoomPutCommandHandler : IRequestHandler<RoomPutCommand, Room>
        {
            private readonly RadissonDbContext db;

            public RoomPutCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Room> Handle(RoomPutCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Rooms.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate != null, cancellationToken);
                data.Number = request.Number;
                data.Aviable = request.Aviable;
                data.ReservationId = request.ReservationId;
                data.RoomTypeId = request.RoomTypeId;
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
