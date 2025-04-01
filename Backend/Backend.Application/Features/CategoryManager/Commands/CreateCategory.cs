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
    public sealed class CreateCategoryCommand : ICommand
    {
        public string Name { get; set; } = null!;
        public string DefaultUnit { get; set; } = null!;
    }

    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateCategoryCommand>
    {

        private readonly ITRepository<Category> _repo;
        private readonly IUnityOfWork _unityOfWork;
        public CreateProductCommandHandler(ITRepository<Category> repo, IUnityOfWork unityOfWork)
        {
            _repo = repo;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Name = request.Name,
                DefaultUnit = request.DefaultUnit,
            };

            _repo.Add(category);
            await _unityOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success("the category is created");
        }
    }
}
