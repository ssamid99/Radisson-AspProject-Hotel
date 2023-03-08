using MediatR;
using Microsoft.AspNetCore.Mvc;
using Radisson.Domain.Business.BlogPostModule;
using Radisson.Domain.Business.RoomTypeModule;
using System.Threading.Tasks;

namespace Radisson.WebUI.AppCode.ViewComponents.RecentRooms
{
    public class RecentRoomsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RecentRoomsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new RoomTypesRecentQuery() { Size = 3 };
            var post = await mediator.Send(query);
            return View(post);
        }
    }
}
