using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.RoomModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using Radisson.Domain.Validators;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public RoomsController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize("admin.rooms.index")]
        public async Task<IActionResult> Index(RoomGetAllQuery query)
        {

            var response = await mediator.Send(query);
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            return View(response);
        }

        [Authorize("admin.rooms.details")]
        public async Task<IActionResult> Details(RoomGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NoContent();
            }
            ViewBag.GetRTName = new Func<int, string>(GetRTName);
            return View(response);
        }

        [Authorize("admin.rooms.create")]
        public IActionResult Create()
        {
            ViewBag.RoomType = new SelectList(db.RoomTypes.Where(rt=>rt.DeletedDate == null).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.rooms.create")]
        public async Task<IActionResult> Create(RoomPostCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", command);
            }
            else
            {
                var reponse = await mediator.Send(command);
                ViewBag.RoomType = new SelectList(db.RoomTypes, "Id", "Name");
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize("admin.rooms.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewBag.RoomType = new SelectList(db.RoomTypes.Where(rt=>rt.DeletedDate ==null), "Id", "Name", room.RoomTypeId);

            var editCommand = new RoomPutCommand();
            editCommand.Id = room.Id;
            editCommand.Number = room.Number;
            editCommand.Aviable = room.Aviable;
            editCommand.RoomTypeId = room.RoomTypeId;
            return View(editCommand);
        }

        // POST: Admin/Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.rooms.edit")]
        public async Task<IActionResult> Edit(RoomPutCommand command)
        {
            //if (id != room.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoomType = new SelectList(db.RoomTypes.Where(rt => rt.DeletedDate == null), "Id", "Name", command.RoomTypeId);
            return View(command);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("admin.rooms.delete")]
        public async Task<IActionResult> DeleteConfirmed(RoomRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public string GetRTName(int id)
        {
            var data = db.RoomTypes.FirstOrDefault(rt => rt.Id == id);
            var name = data.Name;
            return name;
        }
    }
}
