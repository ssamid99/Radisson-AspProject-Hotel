using Coravel.Invocable;
using Radisson.Domain.Models.DbContexts;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Radisson.Domain.AppCode.Services
{
    public class CloseExpiredBooking : IInvocable
    {
        private readonly RadissonDbContext db;

        public CloseExpiredBooking(RadissonDbContext db)
        {
            this.db = db;
        }
        public async Task Invoke()
        {
            var data = db.Reservations.Where(r => r.DeletedDate == null && r.CheckOut < DateTime.Now).ToList();
            foreach (var item in data)
            {
                item.DeletedDate = DateTime.Now;
            }
            db.Reservations.UpdateRange(data);
            var reservationIds = data.Select(d=>d.RoomId).Distinct().ToList();
            var rooms = db.Rooms.Where(r => reservationIds.Contains(r.Id) && r.Aviable == false && r.DeletedDate == null).ToList();
            foreach(var item in rooms)
            {
                item.ReservationId = null;
                item.Aviable = true;
            }
            db.Rooms.UpdateRange(rooms);

            await db.SaveChangesAsync();

            Debug.WriteLine("JobExecuted!");
        }
    }
}
