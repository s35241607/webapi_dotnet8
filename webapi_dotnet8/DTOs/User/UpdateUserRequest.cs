using System.ComponentModel.DataAnnotations;

namespace webapi_dotnet8.DTOs.User
{
    public class UpdateUserRequest
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
