using Booking.BLL.DTOs.AdvertiesementAggregate;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Booking.Utils;
using Booking.BLL.DTOs.RequestHelpers;
using System.Collections.Generic;
using AdvertisementUpdateCommand = Booking.BLL.CQRS.Advertisement.Update.Command;
using AdvertisementCreateCommand = Booking.BLL.CQRS.Advertisement.Create.Command;
using AdvertisementDetailsQuery = Booking.BLL.CQRS.Advertisement.Details.Query;
using AdvertisementGetQuery = Booking.BLL.CQRS.Advertisement.Get.Query;

namespace Booking.API.Endpoints
{
    [ApiController]
    [Route(WebConstants.Advertisement.Routes.BaseRoute)]
    public class AdvertisementEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdvertisementEndpoint(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<AdvertisementEntity>> GetAdvertisementsAsync([FromQuery] AdvertisementFilterDto realtyFilters)
        {
            var query = new AdvertisementDetailsQuery(Response, realtyFilters);
            return await _mediator.Send(query);
        }

        [HttpGet("{id:Guid}", Name = WebConstants.Advertisement.Routes.GetById)]
        public async Task<ActionResult<AdvertisementEntity>> GetAdvertisementByIdAsync(Guid id)
        {
            var query = new AdvertisementGetQuery(id);
            var result = await _mediator.Send(query);

            return result == null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<ActionResult<AdvertisementEntity>> CreateAdvertisement([FromForm] AdvertiesementDto advertisementDto)
        {
            var command = new AdvertisementCreateCommand(advertisementDto);

            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<AdvertisementEntity>> UpdateAdvertisement([FromForm] AdvertiesementDto advertisementDto)
        {
            var command = new AdvertisementUpdateCommand(advertisementDto);
            var result = await _mediator.Send(command);

            return result != null ? Ok(result) : BadRequest();
        }
    }
}
