using MediatR;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.RoomModule
{
    public class RoomPostCommand : IRequest<Room>
    {
        public int Number { get; set; }
        public bool Aviable { get; set; }
        public int? ReservationId { get; set; }
        public int RoomTypeId { get; set; }
        public class RoomPostCommandHandler : IRequestHandler<RoomPostCommand, Room>
        {
            private readonly RadissonDbContext db;

            public RoomPostCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Room> Handle(RoomPostCommand request, CancellationToken cancellationToken)
            {
                var data = new Room();
                data.Number = request.Number;
                data.Aviable = request.Aviable;
                data.ReservationId = request.ReservationId;
                data.RoomTypeId = request.RoomTypeId;
                await db.Rooms.AddAsync(data, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
