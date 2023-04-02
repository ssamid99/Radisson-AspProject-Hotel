using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

namespace Radisson.Domain.Business.AboutModule.ServicesHeaders
{
    public class ServiceHeaderGetAllQuery : PaginateModel, IRequest<PagedViewModel<ServicesHeader>>
    {
        public class ServiceHeaderGetAllQueryHandler : IRequestHandler<ServiceHeaderGetAllQuery, PagedViewModel<ServicesHeader>>
        {
            private readonly RadissonDbContext db;

            public ServiceHeaderGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<ServicesHeader>> Handle(ServiceHeaderGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.ServicesHeaders
                    .Where(r => r.DeletedDate == null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<ServicesHeader>(query, request);
                return pagedModel;
            }
        }
    }
}
