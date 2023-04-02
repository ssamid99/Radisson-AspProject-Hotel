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
    public class ReservationDeletedGetSingleQuery : IRequest<Reservation>
    {
        public int Id { get; set; }
        public class ReservationDeletedGetSingleQueryHandler : IRequestHandler<ReservationDeletedGetSingleQuery, Reservation>
        {
            private readonly RadissonDbContext db;

            public ReservationDeletedGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Reservation> Handle(ReservationDeletedGetSingleQuery request, CancellationToken cancellationToken)
            {
                var query = db.Reservations
                    .Include(re => re.PeopleCloud)
                    .ThenInclude(re => re.People)
                    .AsQueryable();
                return await query.FirstOrDefaultAsync(re => re.Id == request.Id && re.DeletedDate != null, cancellationToken);

            }
        }
    }
}
