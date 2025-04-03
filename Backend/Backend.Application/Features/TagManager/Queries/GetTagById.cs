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
    public sealed class GetTagByIdQuery : IQuery<GetTagByIdDto>
    {
        public int Id { get; set; }
    }
    

        internal sealed class GetTagByIdQueryHanlder : IQueryHandler<GetTagByIdQuery, GetTagByIdDto>
        {
        private readonly ICategoryRepository _repository;

        public GetTagByIdQueryHanlder(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetTagByIdDto>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetById(request.Id);
            if (category == null)
            {
                return Result<GetTagByIdDto>.Failure(["Category not found"]);
            }
            GetTagByIdDto categoryByIdDto = new GetTagByIdDto
            {
                Id = category.Id,
                Name = category.Name,
                DefaultUnit = category.DefaultUnit,
            };
            return Result<GetTagByIdDto>.Success(categoryByIdDto);
        }
    }
}
