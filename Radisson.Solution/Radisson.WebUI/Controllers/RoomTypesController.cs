using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Extensions;
using Radisson.Domain.Business.PaymentModule;
using Radisson.Domain.Business.ReservationModule;
using Radisson.Domain.Business.RoomTypeModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using Radisson.Domain.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Radisson.WebUI.Controllers
{
    [AllowAnonymous]
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
            var userId = User.GetCurrentUserId();

            if (userId > 0)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    ViewBag.Name = user.Name;
                    ViewBag.Surname = user.Surname;
                    ViewBag.Email = user.Email;
                }

            }

            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            ViewBag.People = db.Peoples.Where(p => p.DeletedDate == null).ToList();
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(ReservationPostCommand command)
        {
            var userId = User.GetCurrentUserId();

            if (userId > 0)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    ViewBag.Name = user.Name;
                    ViewBag.Surname = user.Surname;
                    ViewBag.Email = user.Email;
                }

            }
            if (!ModelState.IsValid)
            {
                return View("_ReservationForm", command);
            }
            else
            {
                var response = await mediator.Send(command);
                
                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            
            ViewBag.People = db.Peoples.Where(p => p.DeletedDate == null).ToList();
            return View("_ReservationForm", command);
        }


        public int GetPrice(int id)
        {
            var data = db.RoomTypes.FirstOrDefault(p => p.Id == id);
            int price = data.Price;
            return price;
        }
    }
}
