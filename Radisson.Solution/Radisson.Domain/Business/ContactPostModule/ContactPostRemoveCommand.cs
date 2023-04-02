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

namespace Radisson.Domain.Business.ContactPostModule
{
    public class ContactPostRemoveCommand : IRequest<ContactPost>
    {
        public int Id { get; set; }
        public class ContactPostRemoveCommandHandler : IRequestHandler<ContactPostRemoveCommand, ContactPost>
        {
            private readonly RadissonDbContext db;

            public ContactPostRemoveCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<ContactPost> Handle(ContactPostRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts.FirstOrDefaultAsync(c => c.Id == request.Id && c.DeletedDate == null, cancellationToken);
                if(data == null)
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
