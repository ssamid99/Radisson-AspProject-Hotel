using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Radisson.Domain.AppCode.Extensions;
using Radisson.Domain.AppCode.Infrastructure;
using Radisson.Domain.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Radisson.Domain.Business.AboutModule.Teams
{
    public class TeamPutCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surame { get; set; }
        public string Text { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        public class TeamPutCommandHandler : IRequestHandler<TeamPutCommand, JsonResponse>
        {
            private readonly RadissonDbContext db;
            private readonly IHostEnvironment env;

            public TeamPutCommandHandler(RadissonDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<JsonResponse> Handle(TeamPutCommand request, CancellationToken cancellationToken)
            {
                var entity = db.Teams.FirstOrDefault(bg => bg.Id == request.Id && bg.DeletedDate == null);


                if (entity == null)
                {
                    return null;
                }

                entity.Name = request.Name;
                entity.Surame = request.Surame;
                entity.Text = request.Text;

                if (request.Image == null)
                    goto end;

                string extension = Path.GetExtension(request.Image.FileName); //.jpg-ni goturur
                request.ImagePath = $"team-{Guid.NewGuid().ToString().ToLower()}{extension}";

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
                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }
        }
    }
}
