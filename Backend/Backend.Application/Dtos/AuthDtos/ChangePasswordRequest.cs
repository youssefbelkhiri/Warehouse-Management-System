using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Dtos.AuthDtos
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "Password is required")]
        public string NewPassword { get; set; } = string.Empty;

        [Compare("NewPassword", ErrorMessage = "The password and confirmation password are not the same.")]
        public string RepeatedPassword { get; set; } = string.Empty;
    }
}
