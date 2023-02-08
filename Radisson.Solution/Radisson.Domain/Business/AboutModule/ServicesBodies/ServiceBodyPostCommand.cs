using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Radisson.Domain.AppCode.Extensions;
using Radisson.Domain.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.ServicesBodies
{
    public class ServiceBodyPostCommand : IRequest<JsonResponse>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int ServicesHeaderId { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        public class ServiceBodyPostCommandHandler : IRequestHandler<ServiceBodyPostCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;
            private readonly IHostEnvironment env;

            public ServiceBodyPostCommandHandler(RadissonDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<JsonResponse> Handle(ServiceBodyPostCommand request, CancellationToken cancellationToken)
            {
                var entity = new ServicesBody();

                entity.Title = request.Title;
                entity.Text = request.Text;
                entity.ServicesHeaderId = request.ServicesHeaderId;

                if (request.Image == null)
                    goto end;

                string extension = Path.GetExtension(request.Image.FileName);//.jpg

                request.ImagePath = $"servicesbody-{Guid.NewGuid().ToString().ToLower()}{extension}";
                string fullPath = env.GetImagePhysicalPath(request.ImagePath);

                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    request.Image.CopyTo(fs);
                }

                entity.ImagePath = request.ImagePath;

            end:
                
                await db.ServicesBodies.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }
        }
    }
}
