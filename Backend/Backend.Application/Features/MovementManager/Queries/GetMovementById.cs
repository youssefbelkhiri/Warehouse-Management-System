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

namespace Backend.Application.Features.MovementManager.Queries
{
    public sealed class GetMovementByIdQuery : IQuery<GetMovementByIdDto>
    {
        public int Id { get; set; }
    }
    

        internal sealed class GetMovementByIdQueryHanlder : IQueryHandler<GetMovementByIdQuery, GetMovementByIdDto>
        {
        private readonly IMovementRepository _repository;

        public GetMovementByIdQueryHanlder(IMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetMovementByIdDto>> Handle(GetMovementByIdQuery request, CancellationToken cancellationToken)
        {
            Movement movement = await _repository.GetById(request.Id);
            if (movement == null)
            {
                return Result<GetMovementByIdDto>.Failure(["Category not found"]);
            }
            GetMovementByIdDto categoryByIdDto = new GetMovementByIdDto
            {
                Id = movement.Id,
                MovementType = movement.MovementType,
                Date = movement.Date,
                ProductId = movement.ProductId,
                TotalQuantity = movement.TotalQuantity,
            };
            return Result<GetMovementByIdDto>.Success(categoryByIdDto);
        }
    }
}
