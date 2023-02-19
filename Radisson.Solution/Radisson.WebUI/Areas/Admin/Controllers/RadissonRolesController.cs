using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.RadissonRoleModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities.Membership;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RadissonRolesController : Controller
    {
        private readonly RadissonDbContext _context;
        private readonly RoleManager<RadissonRole> roleManager;
        private readonly IMediator mediator;

        public RadissonRolesController(RadissonDbContext context,RoleManager<RadissonRole> roleManager, IMediator mediator)
        {
            _context = context;
            this.roleManager = roleManager;
            this.mediator = mediator;
        }

        [Authorize("admin.radissonroles.index")]
        public async Task<IActionResult> Index(RadissonRoleGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [Authorize("admin.radissonroles.details")]
        public async Task<IActionResult> Details(RadissonRoleGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [Authorize("admin.radissonroles.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RadissonRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.radissonroles.create")]
        public async Task<IActionResult> Create(RadissonRolePostCommand command)
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

        [Authorize("admin.radissonroles.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radissonRole = await _context.RadissonRoles.FindAsync(id);
            if (radissonRole == null)
            {
                return NotFound();
            }
            var editCommand = new RadissonRolePutCommand();
            editCommand.Name = radissonRole.Name;
            return View(editCommand);
        }

        // POST: Admin/RadissonRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.radissonroles.edit")]
        public async Task<IActionResult> Edit(RadissonRolePutCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }


        // POST: Admin/RadissonRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("admin.radissonroles.delete")]
        public async Task<IActionResult> DeleteConfirmed(RadissonRoleRemoveCommand command)
        {
            var respone = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
