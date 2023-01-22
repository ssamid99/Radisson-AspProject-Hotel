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
    public class RoomGetAllQuery : IRequest<List<Room>>
    {
        public class RoomGetAllQueryHandler : IRequestHandler<RoomGetAllQuery, List<Room>>
        {
            private readonly RadissonDbContext db;

            public RoomGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Room>> Handle(RoomGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Rooms.Where(r => r.DeletedDate != null).ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
