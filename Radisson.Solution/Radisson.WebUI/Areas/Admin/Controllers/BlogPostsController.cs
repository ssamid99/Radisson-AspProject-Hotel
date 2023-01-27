using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Domain.Business.BlogPostModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;

namespace Radisson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "sa")]
    public class BlogPostsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public BlogPostsController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        //GET: Admin/BlogPosts
        public async Task<IActionResult> Index(BlogPostGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        //GET: Admin/BlogPosts/Details/5
        public async Task<IActionResult> Details(BlogPostGetSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        //GET: Admin/BlogPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Admin/BlogPosts/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostPostCommand command)
        {
            if (command.Image == null)
            {
                ModelState.AddModelError("ImagePath", "Shekil Gonderilmelidir");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                if (response.Error == false)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(command);
        }

        //GET: Admin/BlogPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .FirstOrDefaultAsync(bp => bp.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            var editCommand = new BlogPostPutCommand();
            editCommand.Id = blogPost.Id;
            editCommand.Title = blogPost.Title;
            editCommand.Body = blogPost.Body;
            editCommand.ImagePath = blogPost.ImagePath;

            return View(blogPost);
        }

        // POST: Admin/BlogPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogPostPutCommand command)
        {
            var response = await mediator.Send(command);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }


        // POST: Admin/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(BlogPostRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Publish")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PublishConfirmed(BlogPostPublishCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeletedPosts(BlogPostGetAllDeletedQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [HttpPost, ActionName("Back")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BackToPosts(BlogPostRemoveBackCommand command)
        {
            var response = await mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeletedPostDetails(BlogPostGetSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost, ActionName("Clear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearDeletedPosts(BlogPostClearCommand command)
        {

            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DeleteComment")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(BlogPostCommentRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
