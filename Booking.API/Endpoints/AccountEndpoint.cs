using System.Threading.Tasks;
using Booking.BLL.DTOs.AuthAggregate;
using Booking.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginCommand = Booking.BLL.CQRS.Account.Login.Command;
using RegisterCommand = Booking.BLL.CQRS.Account.Register.Command;
using UserGetQuery = Booking.BLL.CQRS.User.Get.Query;

namespace Booking.API.Endpoints
{
    [ApiController]
    [Route(WebConstants.Account.Routes.BaseRoute)]
    public class AccountEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost(WebConstants.Account.Routes.Login)]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var command = new LoginCommand(loginDto);
            var result = await _mediator.Send(command);
            return result == null ? Unauthorized() : result;
        }
        
        [HttpPost(WebConstants.Account.Routes.Register)]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var command = new RegisterCommand(registerDto);
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return StatusCode(StatusCodes.Status201Created);
        }
        
        [Authorize]
        [HttpGet(WebConstants.Account.Routes.CurrentUser)]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var query = new UserGetQuery(User.Identity?.Name);
            return await _mediator.Send(query);
        }
    }
}