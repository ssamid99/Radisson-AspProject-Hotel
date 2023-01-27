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
    public class RoomTypeGetAllQuery : IRequest<List<RoomType>>
    {
        public class RoomTypeGetAllQueryHandler : IRequestHandler<RoomTypeGetAllQuery, List<RoomType>>
        {
            private readonly RadissonDbContext db;

            public RoomTypeGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<RoomType>> Handle(RoomTypeGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.RoomTypes.Where(rt => rt.DeletedDate == null).ToListAsync(cancellationToken);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
