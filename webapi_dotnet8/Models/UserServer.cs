namespace webapi_dotnet8.Models
{
    public class UserServer
    {
        public int UserId { get; set; }
        public int ServerId { get; set; }
        public string Role { get; set; } = "Member";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = new();
        public Server Server { get; set; } = new();
    }
}