using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Features.ProductManager.Queries
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
        private readonly IProduitRepository _repository;
        public GetAllProductsQueryHandler(IProduitRepository repository) 
        {
            _repository = repository;
        }

        public async Task<Result<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _repository.GetAll();
            if (products == null)
            {
                return Result<GetAllProductsResponse>.Failure(["there is no category"]);
            }

            GetAllProductsResponse response = new GetAllProductsResponse
            {
                productsResponse = products
            };


            return Result<GetAllProductsResponse>.Success(response);
        }
    }
}
