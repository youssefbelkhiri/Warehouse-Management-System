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
    public class GetAllProductsQuery : IQuery<GetAllProductsResponse>
    {
    }

    public  class GetAllProductsResponse
    {
        public List<Product> productsResponse { get; set; } = new List<Product> { new Product() };
    }

    internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, GetAllProductsResponse>
    {
        private readonly ICategoryRepository _productsRepository;
        public GetAllProductsQueryHandler(ICategoryRepository productsRepository) 
        {
            _productsRepository = productsRepository;
        }

        public Task<Result<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
