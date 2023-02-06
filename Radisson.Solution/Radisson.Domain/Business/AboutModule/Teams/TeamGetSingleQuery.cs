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
    public class TeamGetSingleQuery : IRequest<Team>
    {
        public int Id { get; set; }
        public class TeamGetSingleQueryHandler : IRequestHandler<TeamGetSingleQuery, Team>
        {
            private readonly RadissonDbContext db;

            public TeamGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }

            public async Task<Team> Handle(TeamGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Teams.FirstOrDefaultAsync(bp => bp.Id == request.Id, cancellationToken);
                if (data == null)
                {
                    return null;

                }
                return data;
            }
        }
    }
}
