using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.CategoryManager.Commands
{
    public sealed class DeleteMovementCommand() : ICommand
    {
        public int id { get; set; }
    }

    internal class DeleteCategoryCommandHandler : ICommandHandler<DeleteMovementCommand>
    {
        private readonly ITRepository<Category> _Repository;
        private readonly IUnityOfWork _UnityOfWork;
        public DeleteCategoryCommandHandler(ITRepository<Category> repository, IUnityOfWork unityOfWork)
        {
            _Repository = repository;
            _UnityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {
            bool oprationResult = _Repository.Remove(request.id);
            if (!oprationResult) return Result.Failure(["the categroy notfound"]);
            await _UnityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("category id removed");
        }
    }

}
