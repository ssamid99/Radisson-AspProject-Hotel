using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.AboutModule.ServicesHeaders;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesHeadersController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public ServicesHeadersController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize("admin.servicesheaders.index")]
        public async Task<IActionResult> Index(ServiceHeaderGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [Authorize("admin.servicesheaders.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ServicesHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.servicesheaders.create")]
        public async Task<IActionResult> Create(ServiceHeaderPostCommand command)
        {
            if (ModelState.IsValid)
            {
                var reponse = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        [Authorize("admin.servicesheaders.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesHeader = await db.ServicesHeaders.FindAsync(id);
            if (servicesHeader == null)
            {
                return NotFound();
            }
            var editCommand = new ServiceHeaderPutCommand();
            editCommand.Title = servicesHeader.Title;
            return View(editCommand);
        }

        // POST: Admin/ServicesHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.servicesheaders.edit")]
        public async Task<IActionResult> Edit(ServiceHeaderPutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // POST: Admin/ServicesHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("admin.servicesheaders.delete")]
        public async Task<IActionResult> DeleteConfirmed(ServiceHeaderRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
