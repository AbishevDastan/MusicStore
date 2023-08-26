using System.ComponentModel.DataAnnotations;

namespace Diploma.DTO.User
{
    public class ChangePasswordDto
    {
        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords must be the same, try again.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
