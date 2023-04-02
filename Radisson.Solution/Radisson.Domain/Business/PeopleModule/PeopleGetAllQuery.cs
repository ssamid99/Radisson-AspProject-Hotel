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

namespace Radisson.Domain.Business.PeopleModule
{
    public class PeopleGetAllQuery : PaginateModel, IRequest<PagedViewModel<People>>
    {
        public class PeopleGetAllQueryHandler : IRequestHandler<PeopleGetAllQuery, PagedViewModel<People>>
        {
            private readonly RadissonDbContext db;

            public PeopleGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<People>> Handle(PeopleGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.Peoples
                    .Where(r => r.DeletedDate == null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<People>(query, request);
                return pagedModel;
            }
        }
    }
}
