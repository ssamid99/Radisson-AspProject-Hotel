using MediatR;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.SubscribeModule
{
    public class SubscribeGetAllQuery :PaginateModel, IRequest<PagedViewModel<Subscribe>>
    {
        public class SubscribeGetAllQueryHandler : IRequestHandler<SubscribeGetAllQuery, PagedViewModel<Subscribe>>
        {
            private readonly RadissonDbContext db;

            public SubscribeGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Subscribe>> Handle(SubscribeGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.Subscribes
                    .Where(r => r.DeletedDate == null)
                    .OrderByDescending(r => r.CreatedDate)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<Subscribe>(query, request);
                return pagedModel;
            }
        }
    }
}
