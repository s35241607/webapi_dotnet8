namespace webapi_dotnet8.Models
{
    public class UserChannelPermission
    {
        public int UserId { get; set; }
        public int ChannelId { get; set; }
        public int PermissionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = new();
        public Channel Channel { get; set; } = new();
        public Permission Permission { get; set; } = new();
    }

}