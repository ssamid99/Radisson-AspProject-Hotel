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

namespace Radisson.Domain.Business.AboutModule.ServicesHeaders
{
    public class ServiceHeaderGetAllQuery : IRequest<List<ServicesHeader>>
    {
        public class ServiceHeaderGetAllQueryHandler : IRequestHandler<ServiceHeaderGetAllQuery, List<ServicesHeader>>
        {
            private readonly RadissonDbContext db;

            public ServiceHeaderGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ServicesHeader>> Handle(ServiceHeaderGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ServicesHeaders.Where(r => r.DeletedDate == null).ToListAsync(cancellationToken);
                if (data == null)
                {
                    return null;
                }

                return data;
            }
        }
    }
}
