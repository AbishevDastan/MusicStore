namespace Diploma.DTO
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Role { get; set; } = "Client";
    }
}
