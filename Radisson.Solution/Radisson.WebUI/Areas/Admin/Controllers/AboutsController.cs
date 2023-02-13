using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Radisson.Domain.Business.AboutModule.Abouts;
using Radisson.Domain.Models.DbContexts;
using System.Threading.Tasks;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public AboutsController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize("admin.abouts.index")]
        public async Task<IActionResult> Index(AboutGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [Authorize("admin.abouts.details")]
        public async Task<IActionResult> Details(AboutGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NoContent();
            }
            return View(response);
        }

        [Authorize("admin.abouts.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.abouts.create")]
        public async Task<IActionResult> Create(AboutPostCommand command)
        {
            if (ModelState.IsValid)
            {
                var reponse = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        [Authorize("admin.abouts.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await db.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            var editCommand = new AboutPutCommand();
            editCommand.Title = about.Title;
            editCommand.Count = about.Count;
            return View(editCommand);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.abouts.edit")]
        public async Task<IActionResult> Edit(AboutPutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("admin.abouts.delete")]
        public async Task<IActionResult> DeleteConfirmed(AboutRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
