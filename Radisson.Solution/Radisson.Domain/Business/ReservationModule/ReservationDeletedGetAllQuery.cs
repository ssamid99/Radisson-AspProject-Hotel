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

namespace Radisson.Domain.Business.ReservationModule
{
    public class ReservationDeletedGetAllQuery : IRequest<List<Reservation>>
    {
        public class ReservationDeletedGetAllQueryHandler : IRequestHandler<ReservationDeletedGetAllQuery, List<Reservation>>
        {
            private readonly RadissonDbContext db;

            public ReservationDeletedGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Reservation>> Handle(ReservationDeletedGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations.Where(re => re.DeletedDate != null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
