using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Radisson.WebUI.AppCode.ViewComponents
{
    public class ServiceHeaderBodyViewComponent : ViewComponent
    {
        private readonly RadissonDbContext db;

        public ServiceHeaderBodyViewComponent(RadissonDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var head = await db.ServicesHeaders.Where(h=>h.DeletedDate == null).ToListAsync();
            var body = await db.ServicesBodies.Where(b => b.DeletedDate == null).ToListAsync();

            var model = new ServiceHeaderBodyModel();
            model.ServicesHeaders = head;
            model.ServicesBodies = body;
            return View(model);
        }
    }
}
