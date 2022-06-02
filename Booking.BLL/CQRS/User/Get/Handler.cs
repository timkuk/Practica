using System.Threading;
using System.Threading.Tasks;
using Booking.BLL.DTOs.AuthAggregate;
using Booking.BLL.Interfaces;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.BLL.CQRS.User.Get
{
    public class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public Handler(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            return user == null 
                ? null
                : new UserDto(user.Email, user.PhoneNumber, await _tokenService.GenerateTokenAsync(user));
        }
    }
}