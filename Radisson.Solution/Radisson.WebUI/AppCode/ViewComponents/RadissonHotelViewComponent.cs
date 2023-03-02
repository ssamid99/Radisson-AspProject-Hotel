using MediatR;
using Microsoft.AspNetCore.Mvc;
using Radisson.Domain.Business.AboutModule.RadissonHotels;
using System.Threading.Tasks;

namespace Radisson.WebUI.AppCode.ViewComponents
{
    public class RadissonHotelViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RadissonHotelViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new RadissonHotelGetAllQuery();
            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
