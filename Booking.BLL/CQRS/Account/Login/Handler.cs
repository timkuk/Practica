using System.Threading;
using System.Threading.Tasks;
using Booking.BLL.DTOs.AuthAggregate;
using Booking.BLL.Interfaces;
using Booking.Domain.Entities.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.BLL.CQRS.Account.Login
{
    public class Handler : IRequestHandler<Command, UserDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public Handler(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        
        public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.LoginDto.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.LoginDto.Password))
            {
                return null;
            }

            return new UserDto(user.Email, user.PhoneNumber, await _tokenService.GenerateTokenAsync(user));
        }
    }
}