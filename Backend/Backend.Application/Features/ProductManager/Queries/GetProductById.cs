using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Application.Features.ProductManager.Queries;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.ProductsManager.Queries
{
        public sealed class GetProductByIdQuery : IQuery<GetProductByIdDto>
        {
            public int Id { get; set; }
        }
    

        internal sealed class GetProductByIdQueryHanlder : IQueryHandler<GetProductByIdQuery, GetProductByIdDto>
        {
        private readonly IProduitRepository _repository;

        public GetProductByIdQueryHanlder(IProduitRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetProductByIdDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetById(request.Id);
            if (product == null)
            {
                return Result<GetProductByIdDto>.Failure(["Category not found"]);
            }
            GetProductByIdDto categoryByIdDto = new GetProductByIdDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                DefaultQuantityUnit = product.DefaultQuantityUnit,
                HasDetails = product.HasDetails,
            };
            return Result<GetProductByIdDto>.Success(categoryByIdDto);
        }
    }
}
