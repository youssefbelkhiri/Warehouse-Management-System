using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Common.Result;
using MediatR;

namespace Backend.Application.Abstraction.Messaging
{
    public interface IQueryHandler<TQuery , TResponse> : IRequestHandler<TQuery , Result<TResponse>> where TQuery : IQuery<TResponse>
    {

    }
}
