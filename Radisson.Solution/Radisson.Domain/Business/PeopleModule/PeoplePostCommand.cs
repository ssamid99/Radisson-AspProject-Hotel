using MediatR;
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
    public class PeoplePostCommand : IRequest<People>
    {
        public string Text { get; set; }
        public double Price { get; set; }
        public class PeoplePostCommandHandler : IRequestHandler<PeoplePostCommand, People>
        {
            private readonly RadissonDbContext db;

            public PeoplePostCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<People> Handle(PeoplePostCommand request, CancellationToken cancellationToken)
            {
                var data = new People();
                data.Text = request.Text;
                data.Price = request.Price;
                await db.Peoples.AddAsync(data, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
