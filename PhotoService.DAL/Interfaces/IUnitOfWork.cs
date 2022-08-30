using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IImageRepository ImageRepository { get; }
        ICollectionRepository CollectionRepository { get; }

        IRoleRepository RoleRepository { get; }

        Task<int> SaveAsync();
    }
}
