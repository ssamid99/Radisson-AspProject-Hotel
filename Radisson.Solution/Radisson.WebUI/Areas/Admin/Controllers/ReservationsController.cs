using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Extensions;
using Radisson.Domain.Business.ReservationModule;
using Radisson.Domain.Models.DbContexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public ReservationsController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize("admin.reservations.index")]
        public async Task<IActionResult> Index(ReservationGetAllQuery query)
        {
            var response = await mediator.Send(query);
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            return View(response);
        }
        [HttpGet]
        [Authorize("admin.reservations.details")]
        public async Task<IActionResult> Details(ReservationGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            ViewBag.GetRNumber = new Func<int, int>(GetRNumber);
            return View(response);
        }
        [Authorize("admin.reservations.create")]
        public IActionResult Create()
        {
            var userId = User.GetCurrentUserId();

            if (userId > 0)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    ViewBag.Name = user.Name;
                    ViewBag.Surname = user.Surname;
                    ViewBag.Email = user.Email;
                }

            }
            ViewBag.RoomTypes = db.RoomTypes.ToList();
            ViewBag.People = db.Peoples.Where(p => p.DeletedDate == null).ToList();
            return View();
        }

        // POST: Admin/Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.reservations.create")]
        public async Task<IActionResult> Create(ReservationPostCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", command);
            }
            else
            {
                var response = await mediator.Send(command);
                var rooms = await db.Rooms.Where(r => r.RoomTypeId == command.RoomTypeId && r.Aviable == true).ToListAsync();
                if (rooms.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "No rooms are available for the selected room type.");
                    return View(command);
                }
                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));
                }

                var userId = User.GetCurrentUserId();

                if (userId > 0)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        ViewBag.Name = user.Name;
                        ViewBag.Surname = user.Surname;
                        ViewBag.Email = user.Email;
                    }

                }
                ViewBag.RoomTypes = db.RoomTypes.ToList();
                ViewBag.People = db.Peoples.Where(p => p.DeletedDate == null).ToList();
            } 
            return View(command);
        }

        [Authorize("admin.reservations.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await db.Reservations
                .Include(r => r.PeopleCloud)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewBag.RoomTypes = db.RoomTypes.ToList();
            ViewBag.People = db.Peoples.Where(p => p.DeletedDate == null).ToList();
            ViewBag.ReservedPeople = new SelectList(db.ReservePeopleCloud.Where(p => p.ReservationId == id && p.DeletedDate == null).ToList(),"Id","PeopleId");
            ViewBag.GetPText = new Func<int, string>(GetPText);
            var editCommand = new ReservationPutCommand();
            editCommand.Id = reservation.Id;
            editCommand.Name = reservation.Name;
            editCommand.Surname = reservation.Surname;
            editCommand.Email = reservation.Email;
            editCommand.CheckIn = reservation.CheckIn;
            editCommand.CheckOut = reservation.CheckOut;
            editCommand.RoomTypeId = reservation.RoomTypeId;
            editCommand.Price = reservation.Price;
            editCommand.peopleIds = reservation.PeopleCloud.Select(tc => tc.Id).ToArray();
            return View(editCommand);
        }

        // POST: Admin/Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.reservations.edit")]
        public async Task<IActionResult> Edit(ReservationPutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.RoomTypes = db.RoomTypes.ToList();
            ViewBag.People = db.Peoples.Where(p => p.DeletedDate == null).ToList();
            return View(command);
        }

        [HttpGet]
        [Authorize("admin.reservations.confirm")]
        public async Task<IActionResult> Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await db.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewBag.RoomTypes = new SelectList(db.RoomTypes.Where(rt => rt.DeletedDate == null).ToList(), "Id", "Name");
            ViewBag.Rooms = new SelectList(db.Rooms.Where(r => r.Aviable == true && r.RoomTypeId == reservation.RoomTypeId).ToList(), "Id", "Number");
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            return View(reservation);
        }
        [HttpPost]
        [Authorize("admin.reservations.confirm")]
        public async Task<IActionResult> Confirm(ReservationConfirmCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                if (response == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));

                ViewBag.RoomTypes = new SelectList(db.RoomTypes.Where(rt => rt.DeletedDate == null).ToList(), "Id", "Name");
                ViewBag.Rooms = new SelectList(db.Rooms.Where(r => r.Aviable == true && r.RoomTypeId == response.RoomTypeId).ToList(), "Id", "Number");
            }
            return View(command);
        }

        [HttpGet]
        [Authorize("admin.reservations.changeroom")]
        public async Task<IActionResult> ChangeRoom(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await db.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            //ViewBag.RoomTypes = new SelectList(_context.RoomTypes.Where(rt => rt.DeletedDate == null && rt.MaxNumberofPeople >= reservation.NumberofPeople).ToList(), "Id", "Name");
            //ViewBag.Rooms = new SelectList(_context.Rooms.Where(r => r.Aviable == true && r.RoomTypeId == reservation.RoomTypeId).ToList(), "Id", "Number");
            var editCommand = new ReservationChangeRoomCommand();
            editCommand.Id = reservation.Id;
            editCommand.RoomTypeId = reservation.RoomTypeId;
            editCommand.RoomId = (int)reservation.RoomId;
            return View(reservation);
        }

        [HttpPost]
        [Authorize("admin.reservations.changeroom")]
        public async Task<IActionResult> ChangeRoom(ReservationChangeRoomCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                if (response == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewBag.RoomTypes1 = new SelectList(_context.RoomTypes.Where(rt => rt.DeletedDate == null).ToList(), "Id", "Name");
            //ViewBag.Rooms1 = new SelectList(_context.Rooms.Where(r => r.Aviable == true && r.RoomTypeId == command.RoomTypeId).ToList(), "Id", "Number");
            return View(command);
        }

        // POST: Admin/Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize("admin.reservations.delete")]
        public async Task<IActionResult> Delete(int? id, ReservationRemoveCommand command)
        {
            if(command.Id != id)
            {
                return NotFound();
            }
            var response = await mediator.Send(command);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(response);
        }

        [Authorize("admin.reservations.deletedindex")]
        public async Task<IActionResult> DeletedIndex(ReservationDeletedGetAllQuery query)
        {
            var response = await mediator.Send(query);
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            return View(response);
        }
        [HttpGet]
        [Authorize("admin.reservations.deleteddetails")]
        public async Task<IActionResult> DeletedDetails(ReservationDeletedGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            ViewBag.GetRNumber = new Func<int, int>(GetRNumber);
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.reservations.deletedremove")]
        public async Task<IActionResult> DeletedRemove(ReservationDeletedRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(response);
        }
        public string GetRTName(int id)
        {
            var data = db.RoomTypes.FirstOrDefault(rt => rt.Id == id);
            var name = data.Name;
            return name;
        }
        public string GetPText(int id)
        {
            var data = db.Peoples.FirstOrDefault(p => p.Id == id);
            var text = data.Text;
            return text;
        }
        public int GetRNumber(int id)
        {
            var data = db.Rooms.FirstOrDefault(rt => rt.Id == id);
            var number = data.Number;
            return number;
        }
        public JsonResult RoomType()
        {
            var rt = db.RoomTypes.Where(rt=>rt.DeletedDate==null).ToList();
            return new JsonResult(rt);
        }

        public JsonResult Room(int id)
        {
            var rm = db.Rooms.Where(e => e.RoomTypes.Id == id && e.Aviable == true).ToList();
            return new JsonResult(rm);
        }
    }
}
