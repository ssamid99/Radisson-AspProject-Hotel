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

namespace Radisson.Domain.Business.RoomTypeModule
{
    public class RoomTypeRemoveCommand : IRequest<RoomType>
    {
        public int Id { get; set; }
        public class RoomTypeRemoveCommandHandler : IRequestHandler<RoomTypeRemoveCommand, RoomType>
        {
            private readonly RadissonDbContext db;

            public RoomTypeRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<RoomType> Handle(RoomTypeRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.RoomTypes.FirstOrDefaultAsync(rt => rt.Id == request.Id && rt.DeletedDate != null, cancellationToken);
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
