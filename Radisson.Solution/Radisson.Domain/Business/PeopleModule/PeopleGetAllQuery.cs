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
    public class PeopleGetAllQuery : IRequest<List<People>>
    {
        public class PeopleGetAllQueryHandler : IRequestHandler<PeopleGetAllQuery, List<People>>
        {
            private readonly RadissonDbContext db;

            public PeopleGetAllQueryHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<People>> Handle(PeopleGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Peoples.Where(p => p.DeletedDate == null).ToListAsync(cancellationToken);
                if(data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
