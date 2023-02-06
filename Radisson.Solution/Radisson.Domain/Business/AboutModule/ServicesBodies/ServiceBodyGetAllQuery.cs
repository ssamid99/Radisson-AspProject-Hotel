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

namespace Radisson.Domain.Business.AboutModule.ServicesBodies
{
    public class ServiceBodyGetAllQuery : IRequest<List<ServicesBody>>
    {
        public class ServiceBodyGetAllQueryHandLer : IRequestHandler<ServiceBodyGetAllQuery, List<ServicesBody>>
        {
            private readonly RadissonDbContext db;

            public ServiceBodyGetAllQueryHandLer(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ServicesBody>> Handle(ServiceBodyGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ServicesBodies.Where(bp => bp.DeletedDate == null).ToListAsync(cancellationToken);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
