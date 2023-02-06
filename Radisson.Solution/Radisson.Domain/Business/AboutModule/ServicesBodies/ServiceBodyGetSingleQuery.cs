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
    public class ServiceBodyGetSingleQuery : IRequest<ServicesBody>
    {
        public int Id { get; set; }
        public class ServiceBodyGetSingleQueryHandler : IRequestHandler<ServiceBodyGetSingleQuery, ServicesBody>
        {
            private readonly RadissonDbContext db;

            public ServiceBodyGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }

            public async Task<ServicesBody> Handle(ServiceBodyGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ServicesBodies.FirstOrDefaultAsync(bp => bp.Id == request.Id, cancellationToken);
                if (data == null)
                {
                    return null;

                }
                return data;
            }
        }
    }
}
