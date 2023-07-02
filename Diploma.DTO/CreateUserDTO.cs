﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DTO
{
    public class CreateUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords are must be the same, try again.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
