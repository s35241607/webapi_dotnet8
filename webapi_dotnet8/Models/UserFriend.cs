namespace webapi_dotnet8.Models
{
    public class UserFriend
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = new();
        public User Friend { get; set; } = new();
    }
}