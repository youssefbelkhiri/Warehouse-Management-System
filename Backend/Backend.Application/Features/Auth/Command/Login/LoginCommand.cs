using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Application.Dtos.AuthDtos;
using Backend.Domain.Common.Result;

namespace Backend.Application.Features.Auth.Command.Login
{
    public sealed record LoginCommand(string Username , string Password ) : ICommand<LoginResponseDto>;
}
