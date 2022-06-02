using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Booking.Utils;
using Query = Booking.BLL.CQRS.Filters.Query;

namespace Booking.API.Endpoints
{
    [ApiController]
    [Route(WebConstants.Filter.Routes.BaseRoute)]
    public class FilterEndpoint : Controller
    {
        private readonly IMediator _mediator;

        public FilterEndpoint(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetFilters()
        {
            var query = new Query();
            var result = await _mediator.Send(query);
            return Ok(new { result.Cities, result.Countries, result.Rooms, result.MaxPrice, result.MinPrice });
        }
    }
}
