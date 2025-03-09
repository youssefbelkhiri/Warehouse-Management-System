using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Application.Services.Security
{
    public interface ITokenService
    {
        Task<string> GenerateToken(AppUser user);
        Task<string> GenerateRefreshToken();
    }
}
