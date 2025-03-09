using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;

namespace Backend.Application.Features.Users.Command.CreateUser
{
    public sealed record CreateUserCommand(string username , string role , string fname, string email , string lname) : ICommand
    {
    }
}
