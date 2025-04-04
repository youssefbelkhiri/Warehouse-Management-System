using Backend.Api.Controllers.Common;
using Backend.Application.Features.TagManager.Commands;
using Backend.Application.Features.TagManager.Queries;
using Backend.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TagController : BaseApiController
    {
        public TagController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<GetAllTagResponse> response = await _sender.Send(new GetAllTagsQuery());
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Result<GetTagByIdDto> response = await _sender.Send(new GetTagByIdQuery { Id = id });
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagCommand tag)
        {
            Result response = await _sender.Send(tag);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagCommand tag)
        {
            tag.Id = id;
            Result response = await _sender.Send(tag);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Result response = await _sender.Send(new DeleteTagCommand { Id = id });
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }
    }
}
