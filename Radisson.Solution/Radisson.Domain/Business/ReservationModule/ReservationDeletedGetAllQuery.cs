﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Infrastructure;
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
    public class ReservationDeletedGetAllQuery : PaginateModel, IRequest<PagedViewModel<Reservation>>
    {
        public class ReservationDeletedGetAllQueryHandler : IRequestHandler<ReservationDeletedGetAllQuery, PagedViewModel<Reservation>>
        {
            private readonly RadissonDbContext db;

            public ReservationDeletedGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Reservation>> Handle(ReservationDeletedGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.Reservations
                    .Where(r => r.DeletedDate != null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<Reservation>(query, request);
                return pagedModel;
            }
        }
    }
}
