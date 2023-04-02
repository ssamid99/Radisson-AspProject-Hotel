using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using Radisson.Application.AppCode.Extensions;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.RadissonHotels
{
    public class RadissonHotelPostCommand : IRequest<RadissonHotel>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string FullText { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public class RadissonHotelPostCommandHandler : IRequestHandler<RadissonHotelPostCommand, RadissonHotel>
        {
            private readonly RadissonDbContext db;
            private readonly IHostEnvironment env;
            private readonly IActionContextAccessor ctx;

            public RadissonHotelPostCommandHandler(RadissonDbContext db, IHostEnvironment env, IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }
            public async Task<RadissonHotel> Handle(RadissonHotelPostCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    var entity = new RadissonHotel();
                    entity.Title = request.Title;
                    entity.Text = request.Text;
                    entity.FullText = request.FullText;
                    entity.CreatedByUserId = ctx.GetCurrentUserId();
                    if (request.Image == null)
                        goto end;

                    string extension = Path.GetExtension(request.Image.FileName);//.jpg

                    request.ImagePath = $"hotel-{Guid.NewGuid().ToString().ToLower()}{extension}";
                    string fullPath = env.GetImagePhysicalPath(request.ImagePath);

                    using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    {
                        request.Image.CopyTo(fs);
                    }

                    entity.ImagePath = request.ImagePath;
                    
                    end:
                    await db.RadissonHotels.AddAsync(entity, cancellationToken);
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
