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
    public class PeopleGetSingleQuery : IRequest<People>
    {
        public int Id { get; set; }
        public class PeopleGetSingleQueryHandler : IRequestHandler<PeopleGetSingleQuery, People>
        {
            private readonly RadissonDbContext db;

            public PeopleGetSingleQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<People> Handle(PeopleGetSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Peoples.FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedDate == null, cancellationToken);
                if(data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
