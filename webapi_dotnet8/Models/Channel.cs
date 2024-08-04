using HotChocolate.Utilities;

namespace webapi_dotnet8.Models
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string Name { get; set; } = null!;
        public int ServerId { get; set; }
        public int ChannelTypeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public Server Server { get; set; } = new();
        public ChannelType ChannelType { get; set; } = new();
        public ICollection<Message> Messages { get; set; } = [];
        public ICollection<UserChannelPermission> UserChannelPermissions { get; set; } = [];

    }

}