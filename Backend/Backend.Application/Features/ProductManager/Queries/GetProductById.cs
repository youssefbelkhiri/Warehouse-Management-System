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
        public sealed class GetProductByIdQuery : IQuery<GetProductByIdDto>
        {
            public int Id { get; set; }
        }
    

        internal sealed class GetProductByIdQueryHanlder : IQueryHandler<GetProductByIdQuery, GetProductByIdDto>
        {
        private readonly ICategoryRepository _repository;

        public GetProductByIdQueryHanlder(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<GetProductByIdDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
