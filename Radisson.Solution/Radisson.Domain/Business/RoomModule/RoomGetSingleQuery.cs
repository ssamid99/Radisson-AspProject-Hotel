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
    public class RoomGetSingleQuery : IRequest<Room>
    {
        public int Id { get; set; }
        public class RoomGetSingleHandler : IRequestHandler<RoomGetSingleQuery, Room>
        {
            private readonly RadissonDbContext db;

            public RoomGetSingleHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Room> Handle(RoomGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Rooms.FirstOrDefaultAsync(r =>r.Id == request.Id && r.DeletedDate != null, cancellationToken);
                return data;
            }
        }
    }
}
