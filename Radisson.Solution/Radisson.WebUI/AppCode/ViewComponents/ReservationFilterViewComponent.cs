using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Radisson.WebUI.AppCode.ViewComponents
{
    public class ReservationFilterViewComponent : ViewComponent
    {
        private readonly RadissonDbContext db;

        public ReservationFilterViewComponent(RadissonDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(Reservation reservation)
        {
            var rooms = db.Rooms.Where(r => r.Aviable == true && r.DeletedDate == null).ToList();
            var roomTypeIds = rooms.Select(r => r.RoomTypeId).Distinct().ToList();
            ViewBag.RoomTypes = db.RoomTypes.Where(rt => roomTypeIds.Contains(rt.Id) && rt.DeletedDate == null).ToList();
            return View(reservation);
        }
    }
}
