using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? UserName { get; set; }
    }
}