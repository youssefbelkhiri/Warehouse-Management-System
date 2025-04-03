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
    public class GetAllMovementsQuery : IQuery<GetAllMovementsResponse>
    {
    }

    public  class GetAllMovementsResponse
    {
        public List<Movement> MovementsResponse { get; set; } = new List<Movement> { new Movement() };
    }

    internal sealed class GetAllMovementsQueryHandler : IQueryHandler<GetAllMovementsQuery, GetAllMovementsResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllMovementsQueryHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Result<GetAllMovementsResponse>> Handle(GetAllMovementsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
