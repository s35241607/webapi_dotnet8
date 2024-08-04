namespace webapi_dotnet8.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<UserServer> UserServers { get; set; } = [];
        public ICollection<Message> Messages { get; set; } = [];
        public ICollection<UserChannelPermission> UserChannelPermissions { get; set; } = [];
        public ICollection<UserFriend> Friends { get; set; } = [];
        public ICollection<DirectMessage> SentMessages { get; set; } = [];
        public ICollection<DirectMessage> ReceivedMessages { get; set; } = [];
    }

}
