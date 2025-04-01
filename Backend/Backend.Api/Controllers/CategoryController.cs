using Backend.Api.Controllers.Common;
using Backend.Application.Features.CategoryManager.Commands;
using Backend.Application.Features.CategoryManager.Queries;
using Backend.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : BaseApiController
    {
        public CategoryController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            Result<GetAllResponse> response = await _sender.Send(new GetAllCategoriesQuery());
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById([FromRoute] int id) 
        {
            Result<GetCategoryByIdDto> response = await _sender.Send(new GetCategoryByIdQuery { Id = id});
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand category) 
        {
            Result response = await _sender.Send(category);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand category) 
        {
            category.Id = id;
            Result response = await _sender.Send(category);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            Result response = await _sender.Send(new DeleteCategoryCommand { id = id });
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }
    }
}
