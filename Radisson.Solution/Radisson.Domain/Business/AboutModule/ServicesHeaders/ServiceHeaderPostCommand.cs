using MediatR;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.ServicesHeaders
{
    public class ServiceHeaderPostCommand : IRequest<ServicesHeader>
    {
        public string Title { get; set; }
        public class ServiceHeaderPostCommandHandler : IRequestHandler<ServiceHeaderPostCommand, ServicesHeader>
        {
            private readonly RadissonDbContext db;

            public ServiceHeaderPostCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<ServicesHeader> Handle(ServiceHeaderPostCommand request, CancellationToken cancellationToken)
            {
                var data = new ServicesHeader();
                data.Title = request.Title;
                await db.ServicesHeaders.AddAsync(data, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
