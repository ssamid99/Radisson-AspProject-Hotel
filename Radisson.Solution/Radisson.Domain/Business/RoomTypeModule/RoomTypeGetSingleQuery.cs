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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Radisson.Domain.Business.RoomTypeModule
{
    public class RoomTypeGetSingleQuery : IRequest<RoomType>
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public class RoomTypeGetSingleQueryHandler : IRequestHandler<RoomTypeGetSingleQuery, RoomType>
        {
            private readonly RadissonDbContext db;

            public RoomTypeGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }

            public async Task<RoomType> Handle(RoomTypeGetSingleQuery request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrWhiteSpace(request.Slug))
                {
                  var data = await db.RoomTypes.FirstOrDefaultAsync(rt => rt.Id == request.Id && rt.DeletedDate == null, cancellationToken);

                    if (data == null)
                    {
                        return null;
                    }
                    return data;
                }
                return await db.RoomTypes.FirstOrDefaultAsync(rt=>rt.Slug.Equals(request.Slug) && rt.DeletedDate == null, cancellationToken);
            }
        }
    }
}
