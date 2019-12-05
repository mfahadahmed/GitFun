using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }

        public string Name { get; set; }
    }

    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]

        public string Password { get; set; }
    }
}
