using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Dtos.AuthDtos;
using Backend.Domain.Entities;

namespace Backend.Application.Services.Security
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto userRequest);
    }
}
