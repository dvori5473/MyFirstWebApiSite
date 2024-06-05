using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string? Password { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address"), Required]
        public string? UserName { get; set; }
    }
}
