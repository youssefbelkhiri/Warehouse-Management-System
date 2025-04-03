using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.CategoryManager.Queries
{
        public sealed class GetCategoryByIdQuery : IQuery<GetCategoryByIdDto>
        {
            public int Id { get; set; }
        }


    internal sealed class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdDto>
        {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetCategoryByIdDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetById(request.Id);
            if (category == null)
            {
                return Result<GetCategoryByIdDto>.Failure(["Category not found"]);
            }
            GetCategoryByIdDto categoryByIdDto = new GetCategoryByIdDto
            {
                Id = category.Id,
                Name = category.Name,
                DefaultUnit = category.DefaultUnit,
            };
            return Result<GetCategoryByIdDto>.Success(categoryByIdDto);
        }
    }
}
