using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.AboutModule.Teams;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Radisson.WebUI.AppCode.ViewComponents.TeamsGrid
{
    public class TeamsGridViewComponent : ViewComponent
    {
        private readonly RadissonDbContext db;

        public TeamsGridViewComponent(RadissonDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await db.Teams.Where(t => t.DeletedDate == null).ToListAsync();
            if(data == null)
            {
                return null;
            }
            return View(data);
        }
    }
}
