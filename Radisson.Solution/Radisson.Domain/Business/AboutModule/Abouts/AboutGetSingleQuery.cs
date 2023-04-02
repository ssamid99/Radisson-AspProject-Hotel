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
    public class AboutGetSingleQuery : IRequest<About>
    {
        public int Id { get; set; }
        public class AboutGetSingleQueryHandler : IRequestHandler<AboutGetSingleQuery, About>
        {
            private readonly RadissonDbContext db;

            public AboutGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<About> Handle(AboutGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Abouts.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
