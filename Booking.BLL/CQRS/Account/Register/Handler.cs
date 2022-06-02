using System.Threading;
using System.Threading.Tasks;
using Booking.Domain.Entities.UserAggregate;
using Booking.Utils;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.BLL.CQRS.Account.Register
{
    public class Handler: IRequestHandler<Command, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public Handler(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public async Task<IdentityResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.RegisterDto.UserName,
                Email = request.RegisterDto.Email,
                PhoneNumber = request.RegisterDto.PhoneNumber
            };
            
            var result = await _userManager.CreateAsync(user, request.RegisterDto.Password);
            
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, WebConstants.Account.MemberRole);
            }

            return result;
        }
    }
}