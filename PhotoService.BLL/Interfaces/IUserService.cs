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
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUser(string id);
        UserModel GetUserByEmail(string email);
        void Create(UserRegisterModel user);
        string Autheticate(string email, string password);
        void VerifyUser(string email);

    }
}
