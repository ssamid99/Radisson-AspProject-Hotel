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

namespace Radisson.Domain.Business.AboutModule.Teams
{
    public class TeamGetAllQuery : IRequest<List<Team>>
    {
        public class TeamGetAllQueryHandLer : IRequestHandler<TeamGetAllQuery, List<Team>>
        {
            private readonly RadissonDbContext db;

            public TeamGetAllQueryHandLer(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Team>> Handle(TeamGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Teams.Where(bp => bp.DeletedDate == null).ToListAsync(cancellationToken);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
