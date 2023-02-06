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

namespace Radisson.Domain.Business.AboutModule.RadissonHotels
{
    public class RadissonHotelGetAllQuery : IRequest<List<RadissonHotel>>
    {
        public class RadissonHotelGetAllQueryHandler : IRequestHandler<RadissonHotelGetAllQuery, List<RadissonHotel>>
        {
            private readonly RadissonDbContext db;

            public RadissonHotelGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<RadissonHotel>> Handle(RadissonHotelGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.RadissonHotels.Where(r => r.DeletedDate == null)
                    .Include(r=>r.Images)
                    .ToListAsync(cancellationToken);
                if(data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
