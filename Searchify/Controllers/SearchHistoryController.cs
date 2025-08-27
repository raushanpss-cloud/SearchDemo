using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Searchify.Domain.Model;

namespace SearchDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly string _filePath = "Data/Products.json";

        public SearchHistoryController()
        {
            
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSearchdata()
        {
            try
            {

                //var filePath = Path.Combine(Directory.GetCurrentDirectory(), _filePath);
                string jsonString = System.IO.File.ReadAllText(_filePath);
                return Ok(jsonString);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "An unexpected error occurred.", Detail = ex.Message });
            }
        }
    }
}
