﻿using Backend.Api.Controllers.Common;
using Backend.Application.Features.ProductManager.Queries;
using Backend.Application.Features.ProductManager.Commands.CreateProduct;
using Backend.Application.Features.ProductManager.Commands.DeleteProduct;
using Backend.Application.Features.ProductManager.Commands.UpdateProduct;
using Backend.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Features.ProductsManager.Queries;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : BaseApiController
    {
        public ProductController(ISender sender) : base(sender) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Result<GetAllProductsResponse> response = await _sender.Send(new GetAllProductsQuery());
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Result<GetProductByIdDto> response = await _sender.Send(new GetProductByIdQuery { Id = id });
            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand product)
        {
            Result response = await _sender.Send(product);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand product)
        {
            product.Id = id;
            Result response = await _sender.Send(product);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Result response = await _sender.Send(new DeleteProductCommand { Id = id });
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Message);
        }
    }
}
