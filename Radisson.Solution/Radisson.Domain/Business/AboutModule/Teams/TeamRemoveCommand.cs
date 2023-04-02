using MediatR;
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
    public class TeamRemoveCommand : IRequest<Team>
    {
        public int Id { get; set; }
        public class TeamRemoveCommandHandler : IRequestHandler<TeamRemoveCommand, Team>
        {
            private readonly RadissonDbContext db;

            public TeamRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }

            public async Task<Team> Handle(TeamRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = db.Teams.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);

                if (data == null)
                {
                    return null;
                }
                data.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
