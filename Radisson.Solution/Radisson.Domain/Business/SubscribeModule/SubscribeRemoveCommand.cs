using MediatR;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.SubscribeModule
{
    public class SubscribeRemoveCommand : IRequest<Subscribe>
    {
        public int Id { get; set; }
        public class SubscribeRemoveCommandHandler : IRequestHandler<SubscribeRemoveCommand, Subscribe>
        {
            private readonly RadissonDbContext db;

            public SubscribeRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<Subscribe> Handle(SubscribeRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Subscribes.FirstOrDefaultAsync(s => s.Id == request.Id && s.DeletedDate == null, cancellationToken);
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
