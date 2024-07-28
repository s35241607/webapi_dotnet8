using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using webapi_dotnet8.Data;
using webapi_dotnet8.Models;

namespace webapi_dotnet8.Controllers.v1
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
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
