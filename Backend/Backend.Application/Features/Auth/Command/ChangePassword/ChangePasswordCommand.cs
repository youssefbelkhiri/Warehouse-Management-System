using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;

namespace Backend.Application.Features.Auth.Command.ChangePassword
{
    public sealed record ChangePasswordCommand(string username , string newPassword , string repeatedPassword) : ICommand
    {
    }
}
