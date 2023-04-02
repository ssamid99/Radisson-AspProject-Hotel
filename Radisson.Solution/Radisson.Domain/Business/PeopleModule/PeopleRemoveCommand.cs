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

namespace Radisson.Domain.Business.PeopleModule
{
    public class PeopleRemoveCommand : IRequest<People>
    {
        public int Id { get; set; }
        public class PeopleRemoveCommandHandler : IRequestHandler<PeopleRemoveCommand, People>
        {
            private readonly RadissonDbContext db;

            public PeopleRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<People> Handle(PeopleRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Peoples.FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedDate == null, cancellationToken);
                if(data == null)
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
