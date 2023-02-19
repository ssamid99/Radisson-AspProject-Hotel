using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.PeopleModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PeopleController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public PeopleController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize("admin.people.index")]
        public async Task<IActionResult> Index(PeopleGetAllQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NoContent();
            }
            return View(response);
        }

        [Authorize("admin.people.details")]
        public async Task<IActionResult> Details(PeopleGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NoContent();
            }
            return View(response);
        }

        [Authorize("admin.people.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.people.create")]
        public async Task<IActionResult> Create(PeoplePostCommand command)
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

        [Authorize("admin.people.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await db.Peoples.FirstOrDefaultAsync(p=>p.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            var editCommand = new PeoplePutCommand();
            editCommand.Text = people.Text;
            editCommand.Price = people.Price;
            return View(editCommand);
        }

        // POST: Admin/People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.people.edit")]
        public async Task<IActionResult> Edit(PeoplePutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        
        // POST: Admin/People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("admin.people.delete")]
        public async Task<IActionResult> DeleteConfirmed(PeopleRemoveCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
    }
}
