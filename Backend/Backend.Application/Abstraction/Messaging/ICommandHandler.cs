using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Common.Result;
using MediatR;

namespace Backend.Application.Abstraction.Messaging
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand , Result> where TCommand : ICommand
    {
    }
    public interface ICommandHandler<TCommand , TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>{}
}
