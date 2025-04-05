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

namespace Backend.Application.Features.TagManager.Queries
{
    public sealed class GetTagByIdQuery : IQuery<GetTagByIdDto>
    {
        public int Id { get; set; }
    }
    

        internal sealed class GetTagByIdQueryHanlder : IQueryHandler<GetTagByIdQuery, GetTagByIdDto>
        {
        private readonly ITagRepository _repository;

        public GetTagByIdQueryHanlder(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetTagByIdDto>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            Tag tag = await _repository.GetById(request.Id);
            if (tag == null)
            {
                return Result<GetTagByIdDto>.Failure(["Category not found"]);
            }
            GetTagByIdDto tagByIdDto = new GetTagByIdDto
            {
                Id = tag.Id,
                Name = tag.Name,
            };
            return Result<GetTagByIdDto>.Success(tagByIdDto);
        }
    }
}
