
namespace webapi_dotnet8.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ChannelId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Channel Channel { get; set; } = new();
        public User User { get; set; } = new();
    }

}