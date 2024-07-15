namespace webapi_dotnet8.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatAt { get; set; }
        public DateTime LastLoginAt { get; set;}
    }
}
