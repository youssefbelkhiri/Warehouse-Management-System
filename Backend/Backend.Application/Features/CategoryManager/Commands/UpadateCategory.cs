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
    public sealed class UpdateCategoryCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DefaultUnit { get; set; } = null!;
    }

    internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly ITRepository<Category> _repository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateCategoryCommandHandler(ITRepository<Category> repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            Category produit = await _repository.GetById(request.Id);

            if (produit == null)
            {
                return Result.Failure(["category notfound"]);
            }

            produit.Id = request.Id;
            produit.Name = request.Name;
            produit.DefaultUnit = request.DefaultUnit;
            

            _repository.Update(produit);
            await _unityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("the Product Is Updated");
        }
    }
}
