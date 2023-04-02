using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("admin.radissonhotels.index")]
        public async Task<IActionResult> Index(RadissonHotelGetAllQuery query)
        {
            var response = await mediator.Send(query);
            bool isTableEmpty = !db.RadissonHotels.Any();
            ViewBag.IsTableEmpty = isTableEmpty;
            return View(response);
        }


        [Authorize("admin.radissonhotels.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RadissonHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.radissonhotels.create")]
        public async Task<IActionResult> Create(RadissonHotelPostCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", command);
            }
            else
            {
                var reponse = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize("admin.radissonhotels.edit")]
        public async Task<IActionResult> Edit(RadissonHotelGetAllQuery query)
        {

            var radissonHotel = await mediator.Send(query);
            if (radissonHotel == null)
            {
                return NotFound();
            }
            var editCommand = new RadissonHotelPutCommand();
            editCommand.Title = radissonHotel.Title;
            editCommand.Text = radissonHotel.Text;
            editCommand.FullText = radissonHotel.FullText;
            editCommand.ImagePath = radissonHotel.ImagePath;
            return View(editCommand);
        }

        // POST: Admin/RadissonHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.radissonhotels.edit")]
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
