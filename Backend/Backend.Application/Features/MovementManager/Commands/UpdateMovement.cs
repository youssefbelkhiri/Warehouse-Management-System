using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Application.Features.MovementManager.Commands
{
    public sealed class UpdateMovementCommand : ICommand
    {
        public int Id { get; set; }
        public string MovementType { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int TotalQuantity { get; set; }
    }

    internal sealed class UpdateMovementCommandHandler : ICommandHandler<UpdateMovementCommand>
    {
        private readonly ITRepository<Movement> _repository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateMovementCommandHandler(ITRepository<Movement> repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Result> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {

            Movement movement = await _repository.GetById(request.Id);

            if (movement == null)
            {
                return Result.Failure(["category notfound"]);
            }

            movement.Id = request.Id;
            movement.MovementType = request.MovementType;
            movement.Date = request.Date;
            movement.ProductId = request.ProductId;
            movement.TotalQuantity = request.TotalQuantity;


            _repository.Update(movement);
            await _unityOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success("the Product Is Updated");
        }
    }
}
