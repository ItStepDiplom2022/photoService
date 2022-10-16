using System.ComponentModel.DataAnnotations;

namespace PhotoService.BLL.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public bool IsVerified { get; set; }

        public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();

    }
}
