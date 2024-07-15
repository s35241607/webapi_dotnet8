using Microsoft.EntityFrameworkCore;
using webapi_dotnet8.Models;

namespace webapi_dotnet8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
