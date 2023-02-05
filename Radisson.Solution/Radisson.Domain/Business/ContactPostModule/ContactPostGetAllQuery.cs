using MediatR;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.ContactPostModule
{
    public class ContactPostGetAllQuery : IRequest<List<ContactPost>>
    {
        public class ContactPostGetAllHandler : IRequestHandler<ContactPostGetAllQuery, List<ContactPost>>
        {
            private readonly RadissonDbContext db;

            public ContactPostGetAllHandler(RadissonDbContext db)
            {
                this.db = db;
            }


            public async Task<List<ContactPost>> Handle(ContactPostGetAllQuery request, CancellationToken cancellationToken)
            {
                var query = await db.ContactPosts.Where(bp => bp.DeletedDate == null)
                                             .ToListAsync(cancellationToken);
                return query;
            }
        }
    }
}
