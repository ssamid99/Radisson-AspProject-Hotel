using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.AppCode.Extensions;
using Radisson.Domain.AppCode.Services;
using Radisson.Domain.Business.ContactPostModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;
        private readonly EmailService emailService;

        public ContactPostsController(RadissonDbContext db, IMediator mediator, EmailService emailService)
        {
            this.db = db;
            this.mediator = mediator;
            this.emailService = emailService;
        }

        // GET: Admin/ContactPosts
        public async Task<IActionResult> Index(ContactPostGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        // GET: Admin/ContactPosts/Details/5
        public async Task<IActionResult> Details(ContactPostGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            ViewBag.UserSN = new Func<int, string>(GetUserNameSurname);
            return View(response);
        }

        // GET: Admin/ContactPosts/Create
        public IActionResult Create()//Bu Action UI ucundur
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
            return View();
        }

        // POST: Admin/ContactPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactPostPostCommand command)//Bu Action UI ucundur
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
               
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
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

            return View(command);
        }

        // GET: Admin/ContactPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = User.GetCurrentUserId();

            if (userId > 0)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    ViewBag.Id = user.Id;
                    
                }

            }

            var contactPost = await db.ContactPosts.FindAsync(id);
            if (contactPost == null)
            {
                return NotFound();
            }
            var editCommand = new ContactPostPutCommand();
            editCommand.Answer = contactPost.Answer;
            editCommand.AnswerDate = contactPost.AnswerDate;
            editCommand.AnsweredbyId = contactPost.AnsweredbyId;
            editCommand.Email = contactPost.Email;
            return View(contactPost);
        }

        // POST: Admin/ContactPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPostPutCommand command)
        {
            var userId = User.GetCurrentUserId();

            if (userId > 0)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    ViewBag.Id = user.Id;

                }

            }
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                await emailService.SendMailAsync(command.Email, "Answer by Admin", command.Answer);
                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(command);
        }

        // POST: Admin/ContactPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ContactPostRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(response);
        }

        public string GetUserNameSurname(int id)
        {
            var data = db.Users.FirstOrDefault(u => u.Id == id);
            var ns = $"{data.Name + data.Surname}";
            return ns;
        }

    }
}
