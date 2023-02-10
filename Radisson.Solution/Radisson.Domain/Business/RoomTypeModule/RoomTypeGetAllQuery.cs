using MediatR;
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

namespace Radisson.Domain.Business.RoomTypeModule
{
    public class RoomTypeGetAllQuery : PaginateModel, IRequest<PagedViewModel<RoomType>>
    {
        public class RoomTypeGetAllQueryHandler : IRequestHandler<RoomTypeGetAllQuery, PagedViewModel<RoomType>>
        {
            private readonly RadissonDbContext db;

            public RoomTypeGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<RoomType>> Handle(RoomTypeGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.RoomTypes
                    .Where(r => r.DeletedDate == null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<RoomType>(query, request);
                return pagedModel;
            }
        }
    }
}
