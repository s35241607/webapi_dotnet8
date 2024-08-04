namespace webapi_dotnet8.Models
{
    public class ChannelType
    {
        public int ChannelTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Channel> Channels { get; set; } = [];
    }
}
