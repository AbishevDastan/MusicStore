using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DTO
{
    public class CreateUserDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The passwords are no the same, try again.")]
        public string ConfirmPassword { get; set; }
    }
}
