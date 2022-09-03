using PhotoService.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserByEmail(string email);
        Task Create(UserRegisterModel user);
        string Autheticate(string email, string password);
        Task VerifyUser(string email);
        UserModel GetUserByUsername(string username);
    }
}
