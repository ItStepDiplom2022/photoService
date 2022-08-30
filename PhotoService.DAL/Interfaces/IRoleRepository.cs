using PhotoService.DAL.Entities;

namespace PhotoService.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Role GetRoleByTitle(string title);
    }
}
