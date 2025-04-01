using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;


namespace Backend.Application.Features.ProductManager.Commands.CreateProduct
{
     internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {

        private readonly ITRepository<Product> _repo;
        private readonly IUnityOfWork _unityOfWork;
        public  CreateProductCommandHandler(ITRepository<Product> repo, IUnityOfWork unityOfWork)
        {
            _repo = repo;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                DefaultQuantityUnit = request.DefaultQuantityUnit,
                HasDetails = request.HasDetails
            };

            _repo.Add(product);
            await _unityOfWork.SaveChangesAsync(cancellationToken);
            
            return Result.Success("the product is created");
        }
    }
}
