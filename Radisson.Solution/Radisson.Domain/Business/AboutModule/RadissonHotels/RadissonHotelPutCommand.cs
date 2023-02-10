using MediatR;
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
        public ImageItem[] Images { get; set; }

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
                    var entity = db.RadissonHotels
                        .Include(p => p.Images)
                         .FirstOrDefault(p => p.Id == request.Id && p.DeletedDate == null);

                    if (entity == null)
                    {
                        return null;
                    }

                    entity.Title = request.Title;
                    entity.Text = request.Text;

                    if (request.Images != null && request.Images.Where(i => i.File != null).Count() > 0)
                    {
                        #region Elave edilen Files
                        foreach (var imageItem in request.Images.Where(i => i.File != null && i.Id == null))
                        {
                            var image = new RadissonHotelImage();
                            image.IsMain = imageItem.IsMain;
                            image.RadissonHotelsId = entity.Id;

                            string extension = Path.GetExtension(imageItem.File.FileName);//.jpg
                            string name = $"hotel-{Guid.NewGuid().ToString().ToLower()}{extension}";

                            string fullName = env.GetImagePhysicalPath(name);

                            using (var fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                            {
                                await imageItem.File.CopyToAsync(fs, cancellationToken);
                            }
                            entity.Images.Add(image);
                        }
                        #endregion

                        #region Movcud shekilerden silinibse
                        foreach (var imageItem in request.Images.Where(i => i.Id > 0 && string.IsNullOrWhiteSpace(i.TempPath)))
                        {
                            var data = await db.RadissonHotelImages.FirstOrDefaultAsync(pi => pi.Id == imageItem.Id && pi.RadissonHotelsId == entity.Id);
                            if (data != null)
                            {
                                data.IsMain = false;
                                data.DeletedDate = DateTime.UtcNow.AddHours(4);
                            }
                        }
                        #endregion

                        #region Deyishiklik edilmeyibse
                        foreach (var imageItem in entity.Images)
                        {
                            var formForm = request.Images.FirstOrDefault(i => i.Id == imageItem.Id);
                            if (formForm != null)
                            {

                                imageItem.IsMain = formForm.IsMain;
                            }
                        }
                        #endregion
                    }

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
