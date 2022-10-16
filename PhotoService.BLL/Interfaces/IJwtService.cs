namespace PhotoService.BLL.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string key, string email, string roles, string username);
    }
}
