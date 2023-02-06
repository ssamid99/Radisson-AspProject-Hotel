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

namespace Radisson.Domain.Business.AboutModule.Abouts
{
    public class AboutPutCommand : IRequest<About>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public class AboutPutCommandHandler : IRequestHandler<AboutPutCommand, About>
        {
            private readonly RadissonDbContext db;

            public AboutPutCommandHandler(RadissonDbContext db)
            {
                this.db = db;
            }
            public async Task<About> Handle(AboutPutCommand request, CancellationToken cancellationToken)
            {
                var data = await db.Abouts.FirstOrDefaultAsync(r => r.Id == request.Id && r.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }
                data.Title = request.Title;
                data.Count = request.Count;
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
