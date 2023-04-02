using MediatR;
using Microsoft.AspNetCore.Mvc;
using Radisson.Domain.Business.BlogPostModule;
using System.Threading.Tasks;

namespace Radisson.WebUI.AppCode.ViewComponents.RecentPosts
{
    public class RecentPostsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RecentPostsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new BlogPostRecentQuery() { Size = 3 };
            var post = await mediator.Send(query);
            return View(post);
        }
    }
}
