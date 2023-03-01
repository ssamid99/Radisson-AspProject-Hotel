using System;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Radisson.WebUI.Controllers
{
    public class RoomTypesController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public RoomTypesController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index(RoomTypeGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(RoomTypeGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }
    }
}
