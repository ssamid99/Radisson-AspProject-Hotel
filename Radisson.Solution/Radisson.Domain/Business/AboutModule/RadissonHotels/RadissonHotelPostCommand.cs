using MediatR;
using Microsoft.Extensions.Hosting;
using Radisson.Domain.AppCode.Extensions;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.RadissonHotels
{
    public class RadissonHotelPostCommand : IRequest<RadissonHotel>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public ImageItem[] Images { get; set; }
        public class RadissonHotelPostCommandHandler : IRequestHandler<RadissonHotelPostCommand, RadissonHotel>
        {
            private readonly RadissonDbContext db;
            private readonly IHostEnvironment env;

            public RadissonHotelPostCommandHandler(RadissonDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<RadissonHotel> Handle(RadissonHotelPostCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    var entity = new RadissonHotel();
                    entity.Title = request.Title;
                    entity.Text = request.Text;
                    

                    if (request.Images != null && request.Images.Where(i => i.File != null).Count() > 0)
                    {
                        entity.Images = new List<RadissonHotelImage>();

                        foreach (var item in request.Images.Where(i => i.File != null))
                        {
                            var image = new RadissonHotelImage();
                            image.IsMain = item.IsMain;
                            string extension = Path.GetExtension(item.File.FileName);//.jpg
                            image.Name = $"hotel-{Guid.NewGuid().ToString().ToLower()}{extension}";

                            string fullName = env.GetImagePhysicalPath(image.Name);

                            using (var fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                            {
                                await item.File.CopyToAsync(fs, cancellationToken);
                            }
                            entity.Images.Add(image);
                        }
                    }

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
