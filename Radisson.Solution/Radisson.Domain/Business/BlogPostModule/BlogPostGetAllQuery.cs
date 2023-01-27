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
    public class BlogPostGetAllQuery : IRequest<List<BlogPost>>
    {
        public class BlogPostGetAllQueryHandLer : IRequestHandler<BlogPostGetAllQuery, List<BlogPost>>
        {
            private readonly RadissonDbContext db;

            public BlogPostGetAllQueryHandLer(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPosts.Where(bp => bp.DeletedDate == null).ToListAsync(cancellationToken);
                if(data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
