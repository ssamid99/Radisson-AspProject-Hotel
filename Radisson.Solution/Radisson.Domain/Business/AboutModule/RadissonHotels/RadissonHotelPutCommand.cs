using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Radisson.Application.AppCode.Extensions;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.RadissonHotels
{
    public class RadissonHotelPutCommand : IRequest<RadissonHotel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string FullText { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        public class RadissonHotelPutCommandHandler : IRequestHandler<RadissonHotelPutCommand, RadissonHotel>
        {
            private readonly RadissonDbContext db;
            private readonly IHostEnvironment env;
            private readonly IActionContextAccessor ctx;

            public RadissonHotelPutCommandHandler(RadissonDbContext db, IHostEnvironment env, IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }
            public async Task<RadissonHotel> Handle(RadissonHotelPutCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = await db.RadissonHotels.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                    if (entity == null)
                    {
                        return null;
                    }

                    entity.Title = request.Title;
                    entity.Text = request.Text;
                    entity.FullText = request.FullText;

                    if (request.Image == null)
                        goto end;

                    string extension = Path.GetExtension(request.Image.FileName); //.jpg-ni goturur
                    request.ImagePath = $"hotel-{Guid.NewGuid().ToString().ToLower()}{extension}";

                    string fullPath = env.GetImagePhysicalPath(request.ImagePath);

                    using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    {
                        request.Image.CopyTo(fs);
                    }

                    string oldPath = env.GetImagePhysicalPath(entity.ImagePath);


                    System.IO.File.Move(oldPath, env.GetImagePhysicalPath($"archive{DateTime.Now:yyyyMMdd}-{entity.ImagePath}"));

                    entity.ImagePath = request.ImagePath;

                end:
                    await db.SaveChangesAsync(cancellationToken);
                    return entity;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }
    }
}
