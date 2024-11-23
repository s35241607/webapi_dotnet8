using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using webapi_dotnet8.Data;

namespace webapi_dotnet8.Controllers.v1
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReservationController(AppDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok();
        }


    }
}
