using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Features.Auth.Command.Logout
{
    internal sealed class LogoutCommandHadler : ICommandHandler<LogoutCommand>
    {
        private readonly UserManager<AppUser> _userManager;

        public LogoutCommandHadler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.username);
            if (user == null)
                return Result.Failure(["User Not Found"]);

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return Result.Success("logout successfully");
        }
    }
}
