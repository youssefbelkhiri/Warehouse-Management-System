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
    public sealed class GetCategoryByIdQuery : IQuery<GetMovementByIdDto>
    {
        public int Id { get; set; }
    }
    

        internal sealed class GetCategiryByIdQueryHanlder : IQueryHandler<GetCategoryByIdQuery, GetMovementByIdDto>
        {
        private readonly ICategoryRepository _repository;

        public GetCategiryByIdQueryHanlder(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetMovementByIdDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetById(request.Id);
            if (category == null)
            {
                return Result<GetMovementByIdDto>.Failure(["Category not found"]);
            }
            GetMovementByIdDto categoryByIdDto = new GetMovementByIdDto
            {
                Id = category.Id,
                Name = category.Name,
                DefaultUnit = category.DefaultUnit,
            };
            return Result<GetMovementByIdDto>.Success(categoryByIdDto);
        }
    }
}
