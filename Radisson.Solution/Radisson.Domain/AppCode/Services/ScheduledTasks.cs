using Coravel.Scheduling.Schedule.Interfaces;
using Radisson.Domain.Models.DbContexts;

namespace Radisson.Domain.AppCode.Services
{
    public class ScheduledTasks
    {
        private readonly RadissonDbContext db;
        private readonly IScheduler _scheduler;

        public ScheduledTasks(RadissonDbContext db, IScheduler scheduler)
        {
            this.db = db;
            _scheduler = scheduler;
        }


        //public void ScheduleFuncAsync()
        //{
        //    _scheduler.Schedule(()=>funcAsync()).EverySecond();
        //}

        //public async Task funcAsync()
        //{
        //    using(db)
        //    {

        //    var data = db.Reservations.Where(r => r.DeletedDate == null && r.CreatedDate < DateTime.Now).ToList();
        //    foreach (var item in data)
        //    {
        //        item.NumberofPeople = 1;
        //    }
        //    db.Reservations.UpdateRange(data);
        //    await db.SaveChangesAsync();
        //    Console.WriteLine("Scheduled task has been completed.");
        //    }
        //}
    }
}
