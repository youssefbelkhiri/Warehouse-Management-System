using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.TagManager.Commands
{
    public sealed record DeleteTagCommand() : ICommand
    {
        public int Id { get; set; }
    }

    internal class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly ITRepository<Tag> _Repository;
        private readonly IUnityOfWork _UnityOfWork;
        public DeleteTagCommandHandler(ITRepository<Tag> repository, IUnityOfWork unityOfWork)
        {
            _Repository = repository;
            _UnityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            bool oprationResult = _Repository.Remove(request.Id);
            if (!oprationResult) return Result.Failure(["the categroy notfound"]);
            await _UnityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("category id removed");
        }
    }
}
