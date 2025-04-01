using Backend.Api.Controllers.Common;
using Backend.Api.Extensions;
using Backend.Application.Dtos.AuthDtos;
using Backend.Application.Features.Auth.Command.ChangePassword;
using Backend.Application.Features.Auth.Command.Login;
using Backend.Application.Features.Auth.Command.Logout;
using Backend.Application.Features.Auth.Query.Refresh;
using Backend.Application.Services.Security;
using Backend.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class AuthController : BaseApiController
    {
        public AuthController(ISender sender) : base(sender)
        {
        }
        [HttpPost("login")]

    public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect Fields Format, Try Again");
            Result<LoginResponseDto> result = await _sender.Send(request);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshQuery refreshRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect Fields Format, Try Again");
            Result<LoginResponseDto> result = await _sender.Send(refreshRequest);
            if (!result.Succeeded) return BadRequest(result.Errors);

            SetCookie("AccessToken", result.Value.Token);
            SetCookie("RefreshToken", result.Value.RefreshToken);

            return Ok();
        }

        [Authorize]
        [HttpPost("chagepassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect Fields Format, Try Again");
            string username = User.GetUsername();
            ChangePasswordCommand changePasswordCommand = new ChangePasswordCommand(username, request.NewPassword , request.RepeatedPassword); 
            Result result = await _sender.Send(changePasswordCommand);
            if(!result.Succeeded) return  BadRequest(result.Errors);
            return Ok(result.Message);
        }


        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect Fields Format, Try Again");
            string username = User.GetUsername();
            LogoutCommand logoutCommand = new LogoutCommand(username);
            Result result = await _sender.Send(logoutCommand);
            if (!result.Succeeded) return BadRequest(result.Errors);
            Response.Cookies.Delete("refreshToken");
            Response.Cookies.Delete("AccessToken");
            return Ok(result.Message);
        }


        private void SetCookie(string TokenName , string Token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,    // Prevent JavaScript access
                Secure = true,      // Only send over HTTPS
                SameSite = SameSiteMode.Strict, // Prevent CSRF attacks
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", Token, cookieOptions);
        }

    }
}
