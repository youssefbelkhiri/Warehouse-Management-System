using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Features.Users.Command.CreateUser
{
    internal class CreateUserCommandHandler: ICommandHandler<CreateUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> Handle(CreateUserCommand request , CancellationToken cancellationToken)
        {
            AppUser user = new AppUser
            {
                UserName = request.username,
                Email = request.email,
                FirstName = request.fname,
                LastName = request.fname,
                IsFirstLogin = true,
            };

            IdentityResult result = await _userManager.CreateAsync(user , "Coding@1234?");

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return Result.Failure(errors);

            }
            IdentityResult resultRole = await _userManager.AddToRoleAsync(user, "Admin");
            if (!resultRole.Succeeded)
            {
                var errors = resultRole.Errors.Select(e => e.Description).ToList();
                return Result.Failure(errors);
            }
                return Result.Success("user created"); 
        }
    }
}
