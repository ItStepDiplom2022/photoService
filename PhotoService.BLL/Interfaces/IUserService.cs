using PhotoService.BLL.Models;

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
