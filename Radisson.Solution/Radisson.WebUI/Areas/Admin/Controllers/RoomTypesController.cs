﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.RoomTypeModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomTypesController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public RoomTypesController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/RoomTypes
        public async Task<IActionResult> Index(RoomTypeGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        // GET: Admin/RoomTypes/Details/5
        public async Task<IActionResult> Details(RoomTypeGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        // GET: Admin/RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoomTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomTypePostCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Admin/RoomTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await db.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            var editCommand = new RoomTypePutCommand();
            editCommand.Id = roomType.Id;
            editCommand.Name = roomType.Name;
            editCommand.Price = roomType.Price;
            editCommand.Description = roomType.Description;
            editCommand.PriceInclude = roomType.PriceInclude;
            editCommand.ImagePath = roomType.ImagePath;
            return View(editCommand);
        }

        // POST: Admin/RoomTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomTypePutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }


        // POST: Admin/RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(RoomTypeRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeExists(int id)
        {
            return db.RoomTypes.Any(e => e.Id == id);
        }
    }
}
