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
    public class RoomRemoveCommand : IRequest<Room>
    {
        public int Id { get; set; }
        public class RoomRemoveCommandHandler : IRequestHandler<RoomRemoveCommand, Room>
        {
            private readonly RadissonDbContext db;

            public RoomRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Room> Handle(RoomRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Rooms.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate == null, cancellationToken);
                if(data == null)
                {
                    return null;
                }
                data.DeletedDate = DateTime.Now.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
