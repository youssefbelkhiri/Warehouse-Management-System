using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.ProductManager.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly ITRepository<Product> _Repository;
        private readonly IUnityOfWork _UnityOfWork;
        public DeleteProductCommandHandler(ITRepository<Product> repository , IUnityOfWork unityOfWork)
        {
            _Repository = repository;
            _UnityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            bool oprationResult = _Repository.Remove(request.id);
            if (!oprationResult) return Result.Failure(["the product notfound"]);
            await _UnityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("Product id removed");
        }
    }
}
