﻿using MediatR;
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
    public class ReservationGetSingleQuery : IRequest<Reservation>
    {
        public int Id;
        public class ReservationGetSingleQueryHandler : IRequestHandler<ReservationGetSingleQuery, Reservation>
        {
            private readonly RadissonDbContext db;

            public ReservationGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Reservation> Handle(ReservationGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Reservations
                    .Include(bp => bp.PeopleCloud)
                    .ThenInclude(bp => bp.People)
                    .FirstOrDefaultAsync(re => re.Id == request.Id && re.DeletedDate == null, cancellationToken);
                return data;
            }
        }
    }
}
