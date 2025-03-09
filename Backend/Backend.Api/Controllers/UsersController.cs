using System.Runtime.InteropServices;
using Backend.Application.Features.Users.Command.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand request)
        {
            var userCreated = await _sender.Send(request);
            if (!userCreated.Succeeded)
            {
                return BadRequest(userCreated.Errors);
            }
            return Ok();
        }
    }
}
