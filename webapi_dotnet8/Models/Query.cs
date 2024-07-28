using webapi_dotnet8.Data;

namespace webapi_dotnet8.Models
{
    public class Query
    {
        public IQueryable<User> GetUsers([Service] AppDbContext db) => db.Users;
    }
}
