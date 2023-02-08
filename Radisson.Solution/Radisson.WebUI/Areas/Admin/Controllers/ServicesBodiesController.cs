using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.AboutModule.ServicesBodies;
using Radisson.Domain.Models.DbContexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesBodiesController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public ServicesBodiesController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/ServicesBodies
        public async Task<IActionResult> Index(ServiceBodyGetAllQuery query)
        {
            var response = await mediator.Send(query);
            ViewBag.GetHeadName = new Func<int, string>(GetHeadName);
            return View(response);
        }

        // GET: Admin/ServicesBodies/Details/5
        public async Task<IActionResult> Details(ServiceBodyGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        // GET: Admin/ServicesBodies/Create
        public IActionResult Create()
        {
            ViewBag.Headers = new SelectList(db.ServicesHeaders.Where(h => h.DeletedDate == null).ToList(), "Id", "Title");
            return View();
        }

        // POST: Admin/ServicesBodies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceBodyPostCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Headers = new SelectList(db.ServicesHeaders.Where(h=>h.DeletedDate == null).ToList(), "Id", "Title", command.ServicesHeaderId);
            return View(command);
        }

        // GET: Admin/ServicesBodies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesBody = await db.ServicesBodies.FindAsync(id);
            if (servicesBody == null)
            {
                return NotFound();
            }
            var editCommand = new ServiceBodyPostCommand();
            editCommand.Title = servicesBody.Title;
            editCommand.Text = servicesBody.Text;
            editCommand.ImagePath = servicesBody.ImagePath;
            editCommand.ServicesHeaderId = servicesBody.ServicesHeaderId;
            ViewBag.Headers = new SelectList(db.ServicesHeaders, "Id", "Title", servicesBody.ServicesHeaderId);
            return View(servicesBody);
        }

        // POST: Admin/ServicesBodies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceBodyPutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Headers = new SelectList(db.ServicesHeaders, "Id", "Title", command.ServicesHeaderId);
            return View(command);
        }

        // POST: Admin/ServicesBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ServiceBodyRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public string GetHeadName(int id)
        {
            var data = db.ServicesHeaders.FirstOrDefault(h => h.Id == id && h.DeletedDate == null);
            return data.Title;
        }
    }
}
