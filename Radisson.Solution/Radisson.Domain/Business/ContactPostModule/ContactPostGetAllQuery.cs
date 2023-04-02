using MediatR;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.ContactPostModule
{
    public class ContactPostGetAllQuery : PaginateModel, IRequest<PagedViewModel<ContactPost>>
    {
        public class ContactPostGetAllHandler : IRequestHandler<ContactPostGetAllQuery, PagedViewModel<ContactPost>>
        {
            private readonly RadissonDbContext db;

            public ContactPostGetAllHandler(RadissonDbContext db)
            {
                this.db = db;
            }


            public async Task<PagedViewModel<ContactPost>> Handle(ContactPostGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.ContactPosts
                    .Where(r => r.DeletedDate == null)
                    .AsQueryable();
                if (query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<ContactPost>(query, request);
                return pagedModel;
            }
        }
    }
}
