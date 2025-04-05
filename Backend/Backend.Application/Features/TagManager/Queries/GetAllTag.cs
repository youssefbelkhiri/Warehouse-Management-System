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
    public class GetAllTagsQuery : IQuery<GetAllTagResponse>
    {
    }

    public  class GetAllTagResponse
    {
        public List<Tag> TagsResponse { get; set; } = new List<Tag> { new Tag() };
    }

    internal sealed class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, GetAllTagResponse>
    {
        private readonly ITagRepository _repository;
        public GetAllTagsQueryHandler(ITagRepository repository) 
        {
            _repository = repository;
        }
        public async Task<Result<GetAllTagResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            List<Tag> tags = await _repository.GetAll();
            if (tags == null)
            {
                return Result<GetAllTagResponse>.Failure(["there is no category"]);
            }

            GetAllTagResponse response = new GetAllTagResponse
            {
                TagsResponse = tags
            };


            return Result<GetAllTagResponse>.Success(response);
        }
    }
}
