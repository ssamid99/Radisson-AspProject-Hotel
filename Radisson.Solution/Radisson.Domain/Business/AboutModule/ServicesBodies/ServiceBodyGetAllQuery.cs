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

namespace Radisson.Domain.Business.AboutModule.ServicesBodies
{
    public class ServiceBodyGetAllQuery : PaginateModel, IRequest<PagedViewModel<ServicesBody>>
    {
        public class ServiceBodyGetAllQueryHandLer : IRequestHandler<ServiceBodyGetAllQuery, PagedViewModel<ServicesBody>>
        {
            private readonly RadissonDbContext db;

            public ServiceBodyGetAllQueryHandLer(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<ServicesBody>> Handle(ServiceBodyGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.ServicesBodies
                    .Where(r => r.DeletedDate == null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<ServicesBody>(query, request);
                return pagedModel;
            }
        }
    }
}
