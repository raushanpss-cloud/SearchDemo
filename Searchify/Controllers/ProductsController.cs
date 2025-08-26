using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Searchify.Application.Commands;

namespace Searchify.API.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var command = new GetAllProductsCommand();
                var result = await _mediator.Send(command);

                if (result == null || !result.Any())
                {
                    return NotFound(new { Message = "No Products found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Detail = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var command = new GetProductByIdCommand(id);
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound(new { Message = $"Product with id {id} not found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "An unexpected error occurred.", Detail = ex.Message });
            }
        }
    }
}
