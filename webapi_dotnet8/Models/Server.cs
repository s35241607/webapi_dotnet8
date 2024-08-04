namespace webapi_dotnet8.Models
{
    public class Server
    {
        public int ServerId { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User Owner { get; set; } = new();
        public ICollection<Channel> Channels { get; set; } = [];
        public ICollection<UserServer> UserServers { get; set; } = [];
    }
}