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
    public class RadissonHotelGetAllQuery : IRequest<RadissonHotel>
    {
        public class RadissonHotelGetAllQueryHandler : IRequestHandler<RadissonHotelGetAllQuery, RadissonHotel>
        {
            private readonly RadissonDbContext db;

            public RadissonHotelGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<RadissonHotel> Handle(RadissonHotelGetAllQuery request, CancellationToken cancellationToken)
            {
                var query = db.RadissonHotels
                    .AsQueryable();
                if(query == null)
                {
                    return null;
                }
                return await query.FirstOrDefaultAsync(r=>r.DeletedDate == null, cancellationToken);
            }
        }
    }
}
