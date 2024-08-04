using webapi_dotnet8.Models;

namespace webapi_dotnet8.Data
{
    public class Query
    {
        public IQueryable<User> GetUsers([Service] AppDbContext db) => db.Users;
    }
}
