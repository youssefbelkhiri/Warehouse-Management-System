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

namespace Backend.Application.Features.Auth.Query.Refresh
{
    internal sealed class RefreshQueryHandler : IQueryHandler<RefreshQuery, LoginResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public RefreshQueryHandler(UserManager<AppUser> userManager , ITokenService tokenService) 
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<Result<LoginResponseDto>> Handle(RefreshQuery request, CancellationToken cancellationToken)
        {
            var user =  _userManager.Users.FirstOrDefault( x => x.RefreshToken == request.RefreshToken );

            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
                return Result<LoginResponseDto>.Failure(["Login or password is incorrect"]);

            LoginResponseDto loginResponse = new LoginResponseDto
            {
                Token = await _tokenService.GenerateToken(user),
                RefreshToken = request.RefreshToken,
            };
            return Result<LoginResponseDto>.Success(loginResponse);

        }
    }
}
