using Backend.Api.Controllers.Common;
using Backend.Application.Features.MovementManager.Queries;
using Backend.Application.Features.MovementManager.Commands;
using Backend.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MovementController : BaseApiController
    {
        public MovementController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<GetAllMovementsResponse> response = await _sender.Send(new GetAllMovementsQuery());
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Result<GetMovementByIdDto> response = await _sender.Send(new GetMovementByIdQuery { Id = id });
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovementCommand movement)
        {
            Result response = await _sender.Send(movement);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMovementCommand movement)
        {
            movement.Id = id;
            Result response = await _sender.Send(movement);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Result response = await _sender.Send(new Application.Features.MovementManager.Commands.DeleteMovementCommand { Id = id });
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }
    }
}
