using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;

namespace Backend.Application.Features.MovementManager.Commands
{
    public sealed class CreateMovementCommand : ICommand
    {
        public string MovementType { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int TotalQuantity { get; set; }
    }

    internal sealed class CreateMovementCommandHandler : ICommandHandler<CreateMovementCommand>
    {

        private readonly ITRepository<Movement> _repo;
        private readonly IUnityOfWork _unityOfWork;
        public CreateMovementCommandHandler(ITRepository<Movement> repo, IUnityOfWork unityOfWork)
        {
            _repo = repo;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            Movement movement = new Movement
            {
                MovementType = request.MovementType,
                Date = request.Date,
                ProductId = request.ProductId,
                TotalQuantity = request.TotalQuantity,
            };

            _repo.Add(movement);
            await _unityOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success("the movement is created");
        }
    }
}
