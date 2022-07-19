using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<string> Roles { get; set; } = new List<string>();

    }
}
