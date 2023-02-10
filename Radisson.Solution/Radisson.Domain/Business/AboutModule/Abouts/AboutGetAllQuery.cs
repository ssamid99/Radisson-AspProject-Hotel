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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Radisson.Domain.Business.AboutModule.Abouts
{
    public class AboutGetAllQuery :PaginateModel, IRequest<PagedViewModel<About>>
    {
        public class AboutGetAllQueryHandler : IRequestHandler<AboutGetAllQuery, PagedViewModel<About>>
        {
            private readonly RadissonDbContext db;

            public AboutGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<About>> Handle(AboutGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.Abouts
                    .Where(r => r.DeletedDate == null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<About>(query, request);
                return pagedModel;
            }
        }
    }
}
