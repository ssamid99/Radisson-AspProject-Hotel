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

namespace Radisson.Domain.Business.PeopleModule
{
    public class PeoplePutCommand : IRequest<People>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Price { get; set; }
        public class PesoplePutCommandHandler : IRequestHandler<PeoplePutCommand, People>
        {
            private readonly RadissonDbContext db;

            public PesoplePutCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<People> Handle(PeoplePutCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Peoples.FirstOrDefaultAsync(p => p.Id == request.Id && p.DeletedDate == null, cancellationToken);

                if(data == null)
                {
                    return null;
                }

                data.Text = request.Text;
                data.Price = request.Price;

                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
