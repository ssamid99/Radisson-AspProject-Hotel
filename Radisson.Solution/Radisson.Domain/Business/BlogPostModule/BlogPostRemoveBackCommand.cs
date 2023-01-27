using MediatR;
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
    public class BlogPostRemoveBackCommand : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public class BlogPostRemoveBackCommandHandler : IRequestHandler<BlogPostRemoveBackCommand, BlogPost>
        {
            private readonly RadissonDbContext db;

            public BlogPostRemoveBackCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }

            public async Task<BlogPost> Handle(BlogPostRemoveBackCommand request, CancellationToken cancellationToken)
            {
                var data = db.BlogPosts.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate != null);

                if (data == null)
                {
                    return null;
                }
                data.DeletedDate = null;
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
