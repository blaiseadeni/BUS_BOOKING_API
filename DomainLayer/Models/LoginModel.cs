
namespace DomainLayer.Models
{
    public class UserDTO
    {
        public required string? UserName { get; set; }
        public required string Password { get; set; }
    }


    public class CurrentUser
    {
        public int UserId { get; set; }
    }

    public class Authenticate
    {
        public string? UserName { get; set; }
        public string? Role { get; set; }
    }
}
