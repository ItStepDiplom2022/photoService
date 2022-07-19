using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Entities
{
    public class User
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsVerified { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
