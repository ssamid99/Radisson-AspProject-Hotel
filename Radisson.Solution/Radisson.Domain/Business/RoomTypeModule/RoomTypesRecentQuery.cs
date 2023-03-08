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

namespace Radisson.Domain.Business.RoomTypeModule
{
    public class RoomTypesRecentQuery : IRequest<List<RoomType>>
    {

        public int Size { get; set; }

        public class RoomTypesRecentQueryHandler : IRequestHandler<RoomTypesRecentQuery, List<RoomType>>
        {
            private readonly RadissonDbContext db;

            public RoomTypesRecentQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<RoomType>> Handle(RoomTypesRecentQuery request, CancellationToken cancellationToken)
            {
                var posts = await db.RoomTypes
                     .Where(bp => bp.DeletedDate == null)
                     .Take(request.Size < 3 ? 3 : request.Size)
                     .ToListAsync(cancellationToken);

                return posts;
            }
        }

    }
}
