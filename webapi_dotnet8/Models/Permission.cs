namespace webapi_dotnet8.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<UserChannelPermission> UserChannelPermissions { get; set; } = [];
    }

}
