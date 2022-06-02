using System.Threading.Tasks;
using Booking.Prepopulator.Interfaces;
using Booking.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Endpoints
{
    [ApiController]
    [Route(WebConstants.Prepopulator.Routes.BaseRoute)]
    public class PrepopulatorEndpoint : ControllerBase
    {
        private readonly IPrepopulatorService _prepopulatorService;
        
        public PrepopulatorEndpoint(IPrepopulatorService prepopulatorService)
        {
            _prepopulatorService = prepopulatorService;
        }

        [HttpGet(WebConstants.Prepopulator.Execute)]
        public async Task<ActionResult> SeedAllDataAsync()
        {
            await _prepopulatorService.SeedAllDataAsync();
            return Ok();
        }
    }
}