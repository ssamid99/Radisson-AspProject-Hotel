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

namespace Radisson.Domain.Business.AboutModule.Abouts
{
    public class AboutGetAllQuery : IRequest<List<About>>
    {
        public class AboutGetAllQueryHandler : IRequestHandler<AboutGetAllQuery, List<About>>
        {
            private readonly RadissonDbContext db;

            public AboutGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<About>> Handle(AboutGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Abouts.Where(r => r.DeletedDate == null).ToListAsync(cancellationToken);
                if (data == null)
                {
                    return null;
                }

                return data;
            }
        }
    }
}
