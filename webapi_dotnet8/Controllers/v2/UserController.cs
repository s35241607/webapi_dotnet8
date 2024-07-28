using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_dotnet8.Data;
using webapi_dotnet8.Models;

namespace webapi_dotnet8.Controllers.v2
{

    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController(AppDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<List<User>> GetUsers()
            => await db.Users.ToListAsync();

        [HttpGet("{id}")]
        public async Task<User?> GetUser(int id)
            => await db.Users.FindAsync(id);

        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}
