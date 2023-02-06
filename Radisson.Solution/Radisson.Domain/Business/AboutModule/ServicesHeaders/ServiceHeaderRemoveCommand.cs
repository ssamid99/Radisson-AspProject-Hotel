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

namespace Radisson.Domain.Business.AboutModule.ServicesHeaders
{
    public class ServiceHeaderRemoveCommand : IRequest<ServicesHeader>
    {
        public int Id { get; set; }
        public class ServiceHeaderRemoveCommandHandler : IRequestHandler<ServiceHeaderRemoveCommand, ServicesHeader>
        {
            private readonly RadissonDbContext db;

            public ServiceHeaderRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<ServicesHeader> Handle(ServiceHeaderRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ServicesHeaders.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }
                data.DeletedDate = DateTime.Now.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
