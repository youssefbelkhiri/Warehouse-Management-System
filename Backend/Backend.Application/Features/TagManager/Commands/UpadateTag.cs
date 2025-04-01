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
    public sealed class UpdateTagCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    internal sealed class UpdateTagCommandHandler : ICommandHandler<UpdateTagCommand>
    {
        private readonly ITRepository<Tag> _repository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateTagCommandHandler(ITRepository<Tag> repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {

            Tag tag = await _repository.GetById(request.Id);

            if (tag == null)
            {
                return Result.Failure(["category notfound"]);
            }

            tag.Id = request.Id;
            tag.Name = request.Name;



            _repository.Update(tag);
            await _unityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("the Product Is Updated");
        }
    }
}
