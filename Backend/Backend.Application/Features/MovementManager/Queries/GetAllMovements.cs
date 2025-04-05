using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Features.MovementManager.Queries
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
        private readonly IMovementRepository _movementRepo;
        public GetAllMovementsQueryHandler(IMovementRepository movementRepo) 
        {
            _movementRepo = movementRepo;
        }

        public async Task<Result<GetAllMovementsResponse>> Handle(GetAllMovementsQuery request, CancellationToken cancellationToken)
        {
            List<Movement> movements = await _movementRepo.GetAll();
            if (movements == null)
            {
                return Result<GetAllMovementsResponse>.Failure(["there is no category"]);
            }

            GetAllMovementsResponse response = new GetAllMovementsResponse
            {
                MovementsResponse = movements
            };


            return Result<GetAllMovementsResponse>.Success(response);
        }
    }
}
