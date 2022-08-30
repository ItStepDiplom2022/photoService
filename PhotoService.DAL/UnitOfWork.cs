using PhotoService.DAL.Interfaces;
using PhotoService.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotoServiceDbContext _dbContext;
        private IImageRepository _imageRepository;
        private IUserRepository _userRepository;
        private ICollectionRepository _collectionRepository;
        private IRoleRepository _roleRepository;

        public UnitOfWork(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);

                return _userRepository;
            }
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new ImageRepository(_dbContext);

                return _imageRepository;
            }
        }

        public ICollectionRepository CollectionRepository
        {
            get
            {
                if (_collectionRepository == null)
                    _collectionRepository = new CollectionRepository(_dbContext);

                return _collectionRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_dbContext);

                return _roleRepository;
            }
        }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
