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
    public class GetAllMovementsQuery : IQuery<GetAllResponse>
    {
    }

    public  class GetAllMovementsResponse
    {
        public List<Movement> MovementsResponse { get; set; } = new List<Movement> { new Movement() };
    }

    internal sealed class GetAllMovementsQueryHandler : IQueryHandler<GetAllCategoriesQuery, GetAllResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllMovementsQueryHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<GetAllResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAll();
            if (categories == null) 
            {
                return Result<GetAllResponse>.Failure(["there is no category"]);
            }

            GetAllResponse response = new GetAllResponse
            {
                categoriesResponse = categories
            };


            return Result<GetAllResponse>.Success(response);
        }
    }
}
