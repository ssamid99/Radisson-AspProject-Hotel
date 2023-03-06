using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Radisson.Application.AppCode.Extensions;
using Radisson.Domain.Business.BlogPostModule;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Radisson.WebUI.Controllers
{
    
    public class BlogPostsController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly IMediator mediator;

        public BlogPostsController(RadissonDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [AllowAnonymous]
        // GET: BlogPosts
        public async Task<IActionResult> Index(BlogPostGetAllQuery query)
        {
            var response = await mediator.Send(query);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PostBody", response);
            }
            return View(response);
        }

        [AllowAnonymous]
        // GET: BlogPosts/Details/5
        public async Task<IActionResult> Details(BlogPostGetSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(BlogPostCommentPostCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return PartialView("_Comment", response);
        }
    }
}
