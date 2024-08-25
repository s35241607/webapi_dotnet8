using Microsoft.EntityFrameworkCore;
using webapi_dotnet8.Models;

namespace webapi_dotnet8.Data
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] AppDbContext db) => db.Users;
    }
}
