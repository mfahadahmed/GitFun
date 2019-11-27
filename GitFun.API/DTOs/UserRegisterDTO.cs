using System.ComponentModel.DataAnnotations;

namespace GitFun.API.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }
}