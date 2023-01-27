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

namespace Radisson.Domain.Business.BlogPostModule
{
    public class BlogPostGetAllDeletedQuery : IRequest<List<BlogPost>>
    {
        public class BlogPostGetAllDeletedHandler : IRequestHandler<BlogPostGetAllDeletedQuery, List<BlogPost>>
        {
            private readonly RadissonDbContext db;

            public BlogPostGetAllDeletedHandler(RadissonDbContext db)
            {
                this.db = db;
            }


            public async Task<List<BlogPost>> Handle(BlogPostGetAllDeletedQuery request, CancellationToken cancellationToken)
            {
                var query = await db.BlogPosts.Where(bp => bp.DeletedDate != null)
                                             .ToListAsync(cancellationToken);
                return query;
            }
        }
    }
}
