using System.ComponentModel.DataAnnotations;

namespace GitFun.API.DTOs
{
    public class UserRegisterDTO
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
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
