using System.Collections.Generic;
using Booking.BLL.DTOs.RequestHelpers;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Booking.BLL.CQRS.Advertisement.Details
{
    public class Query : IRequest<IEnumerable<AdvertisementEntity>>
    {
        public HttpResponse Response { get; }

        public AdvertisementFilterDto AdvertisementFilters { get; }

        public Query(HttpResponse response, AdvertisementFilterDto advertisementFilterDto)
        {
            Response = response;
            AdvertisementFilters = advertisementFilterDto;
        }
    }
}