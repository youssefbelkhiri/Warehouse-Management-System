using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Application.Dtos.AuthDtos;
using Backend.Application.Features.Auth.Command.Login;
using MediatR;

namespace Backend.Application.Features.Auth.Query.Refresh
{
    public sealed record class RefreshQuery(string RefreshToken) : IQuery<LoginResponseDto>
    {
    }
}
