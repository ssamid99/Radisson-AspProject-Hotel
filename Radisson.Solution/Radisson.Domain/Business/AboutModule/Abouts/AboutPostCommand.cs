using MediatR;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.Abouts
{
    public class AboutPostCommand : IRequest<About>
    {
        public string Title { get; set; }
        public int Count { get; set; }
        public class AboutPostCommandHandler : IRequestHandler<AboutPostCommand, About>
        {
            private readonly RadissonDbContext db;

            public AboutPostCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<About> Handle(AboutPostCommand request, CancellationToken cancellationToken)
            {
                var data = new About();
                data.Title = request.Title;
                data.Count = request.Count;
                await db.Abouts.AddAsync(data, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
