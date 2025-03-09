using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Application.Dtos.AuthDtos;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Features.Auth.Command.ChangePassword
{
    internal sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        public ChangePasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            

            var user = await _userManager.FindByNameAsync(request.username);
            if (user == null)
            {
                return Result.Failure(["User not found"]);
            }

            IdentityResult resetPasswordResult = await _userManager.ChangePasswordAsync(user, "Coding@1234?", request.newPassword);
            if (!resetPasswordResult.Succeeded)
            {
                return Result.Failure(resetPasswordResult.Errors.Select(e => e.Description));
            }
            user.IsFirstLogin = false;

            await _userManager.UpdateAsync(user);

            return Result.Success("Password changed successfully");

        }
    }
}
