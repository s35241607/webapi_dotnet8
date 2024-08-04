namespace webapi_dotnet8.Models
{
    public class DirectMessage
    {
        public int DirectMessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User Sender { get; set; } = new();
        public User Receiver { get; set; } = new();
    }

}