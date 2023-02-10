using MediatR;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.BlogPostModule
{
    public class BlogPostGetAllQuery : PaginateModel, IRequest<PagedViewModel<BlogPost>>
    {
        public class BlogPostGetAllQueryHandLer : IRequestHandler<BlogPostGetAllQuery, PagedViewModel<BlogPost>>
        {
            private readonly RadissonDbContext db;

            public BlogPostGetAllQueryHandLer(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostGetAllQuery request, CancellationToken cancellationToken)
            {
                if (request.PageSize < 6)
                {
                    request.PageSize = 6;
                }
                var query = db.BlogPosts
                    .Where(bp => bp.DeletedDate == null)
                    .AsQueryable();
                if(query == null)
                {
                    return null;
                }
                var pagedModel = new PagedViewModel<BlogPost>(query, request);
                return pagedModel;
            }
        }
    }
}
