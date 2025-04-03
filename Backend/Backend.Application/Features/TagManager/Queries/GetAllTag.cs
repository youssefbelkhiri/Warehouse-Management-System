using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Features.CategoryManager.Queries
{
    public class GetAllTagsQuery : IQuery<GetAllTagResponse>
    {
    }

    public  class GetAllTagResponse
    {
        public List<Category> categoriesResponse { get; set; } = new List<Category> { new Category() };
    }

    internal sealed class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, GetAllTagResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllTagsQueryHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<GetAllTagResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAll();
            if (categories == null) 
            {
                return Result<GetAllTagResponse>.Failure(["there is no category"]);
            }

            GetAllTagResponse response = new GetAllTagResponse
            {
                categoriesResponse = categories
            };


            return Result<GetAllTagResponse>.Success(response);
        }
    }
}
