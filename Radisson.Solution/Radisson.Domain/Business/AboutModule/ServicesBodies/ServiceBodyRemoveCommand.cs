using MediatR;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.ServicesBodies
{
    public class ServiceBodyRemoveCommand : IRequest<ServicesBody>
    {
        public int Id { get; set; }
        public class ServiceBodyRemoveCommandHandler : IRequestHandler<ServiceBodyRemoveCommand, ServicesBody>
        {
            private readonly RadissonDbContext db;

            public ServiceBodyRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }

            public async Task<ServicesBody> Handle(ServiceBodyRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = db.ServicesBodies.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);

                if (data == null)
                {
                    return null;
                }
                data.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
