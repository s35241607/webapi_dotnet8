using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using webapi_dotnet8.Data;
using webapi_dotnet8.DTOs.User;
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
        public async Task<User> CreateUser(CreateUserRequest createUser)
        {
            var user = new User()
            {
                Username = createUser.Username,
                Email = createUser.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUser.Password)
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }

        [HttpPut("{id}")]
        public async Task<User?> UpdateUser(int id, UpdateUserRequest updateUser)
        {
            var user = await db.Users.FindAsync(id);

            if (user is null)
                return null;

            user.Username = updateUser.Username;
            user.Email = updateUser.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUser.Password);
            
            db.Entry(user).CurrentValues.SetValues(updateUser);

            await db.SaveChangesAsync();

            return user;
        }
    }
}
