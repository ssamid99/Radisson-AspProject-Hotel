using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

namespace Radisson.Domain.Business.RoomTypeModule
{
    public class RoomTypePutCommand : IRequest<RoomType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberofPeople { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string PriceInclude { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public class RoomTypePutCommandHandler : IRequestHandler<RoomTypePutCommand, RoomType>
        {
            private readonly RadissonDbContext db;
            private readonly IHostEnvironment env;

            public RoomTypePutCommandHandler(RadissonDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<RoomType> Handle(RoomTypePutCommand request, CancellationToken cancellationToken)
            {
                var data = await db.RoomTypes.FirstOrDefaultAsync(rt => rt.Id == request.Id && rt.DeletedDate == null, cancellationToken);
                if(data == null)
                {
                    return null;
                }
                data.Name = request.Name;
                data.MaxNumberofPeople = request.MaxNumberofPeople;
                data.Price = request.Price;
                data.Description = request.Description;
                data.PriceInclude = request.PriceInclude;
                if (request.Image == null)
                    goto end;

                string extension = Path.GetExtension(request.Image.FileName); //.jpg-ni goturur
                request.ImagePath = $"roomtype-{Guid.NewGuid().ToString().ToLower()}{extension}";

                string fullPath = env.GetImagePhysicalPath(request.ImagePath);

                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    request.Image.CopyTo(fs);
                }

                string oldPath = env.GetImagePhysicalPath(data.ImagePath);


                System.IO.File.Move(oldPath, env.GetImagePhysicalPath($"archive{DateTime.Now:yyyyMMdd}-{data.ImagePath}"));

                data.ImagePath = request.ImagePath;

            end:
                if (string.IsNullOrWhiteSpace(data.Slug))
                {
                    data.Slug = request.Name.ToSlug();
                }
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
