using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Application.Dtos.AuthDtos;
using Backend.Application.Services.Security;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Features.Auth.Command.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand , LoginResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                
                return Result<LoginResponseDto>.Failure(["Login or password is incorrect"]);
            }

            SignInResult userConnected = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!userConnected.Succeeded)
            {
                return Result<LoginResponseDto>.Failure([userConnected.ToString()]);
            }

            string refreshToken = await _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(user);

            LoginResponseDto loginResponse = new LoginResponseDto
            {
                Token = await _tokenService.GenerateToken(user),
                RefreshToken = refreshToken,
                RefreshTokenLifeTime = user.RefreshTokenExpiryTime,
                AccessTokenLifeTime = DateTime.Now.AddDays(7)
            };

            return  Result<LoginResponseDto>.Success(loginResponse);
        }
    } 
}
