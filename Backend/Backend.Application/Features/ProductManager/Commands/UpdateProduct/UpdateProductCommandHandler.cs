using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.ProductManager.Commands.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly ITRepository<Product> _repository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateProductCommandHandler(ITRepository<Product> repository , IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            Product produit = await _repository.GetById(request.Id);

            if (produit == null)
            {
                return Result.Failure(["product notfound"]);
            }

            produit.Id = request.Id;
            produit.Name = request.Name;
            produit.CategoryId = request.CategoryId;
            produit.DefaultQuantityUnit = request.DefaultQuantityUnit;
            produit.HasDetails = request.HasDetails;

            _repository.Update(produit);
            await _unityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("the Product Is Updated");
        }
    }
}
