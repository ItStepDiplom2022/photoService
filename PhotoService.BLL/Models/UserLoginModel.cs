using System.ComponentModel.DataAnnotations;

namespace PhotoService.BLL.Models
{
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
