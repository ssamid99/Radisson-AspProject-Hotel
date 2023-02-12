using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.SubscribeModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribesController : Controller
    {
        private readonly IMediator mediator;

        public SubscribesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.subscribes.index")]
        public async Task<IActionResult> Index(SubscribeGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.subscribes.delete")]
        public async Task<IActionResult> DeleteConfirmed(SubscribeRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(response);
        }
    }
}
