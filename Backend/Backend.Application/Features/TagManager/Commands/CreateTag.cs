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
    public sealed class CreateTagCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
    }

    internal sealed class CreateTagCommandHandler : ICommandHandler<CreateTagCommand>
    {

        private readonly ITRepository<Tag> _repo;
        private readonly IUnityOfWork _unityOfWork;
        public CreateTagCommandHandler(ITRepository<Tag> repo, IUnityOfWork unityOfWork)
        {
            _repo = repo;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            Tag tag = new Tag
            {
                Name = request.Name,
            };

            _repo.Add(tag);
            await _unityOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success("the movement is created");
        }
    }
}
