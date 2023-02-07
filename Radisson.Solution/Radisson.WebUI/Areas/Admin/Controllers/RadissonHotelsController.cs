using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.AboutModule.RadissonHotels;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RadissonHotelsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public RadissonHotelsController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/RadissonHotels
        public async Task<IActionResult> Index(RadissonHotelGetAllQuery query)
        {
            var response = await mediator.Send(query);
            bool isTableEmpty = !db.RadissonHotels.Any();
            ViewBag.IsTableEmpty = isTableEmpty;
            return View(response);
        }


        // GET: Admin/RadissonHotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RadissonHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RadissonHotelPostCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Admin/RadissonHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radissonHotel = await db.RadissonHotels.FindAsync(id);
            if (radissonHotel == null)
            {
                return NotFound();
            }
            var editCommand = new RadissonHotelPutCommand();
            editCommand.Title = radissonHotel.Title;
            editCommand.Text = radissonHotel.Text;
            return View(editCommand);
        }

        // POST: Admin/RadissonHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RadissonHotelPutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                if(response == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

    }
}
