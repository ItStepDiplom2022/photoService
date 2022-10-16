using AutoMapper;
using Microsoft.Extensions.Configuration;
using PhotoService.BLL.Enums;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.ExtensionMethods;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.DAL;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;

namespace PhotoService.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly string key;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            key = configuration.GetSection("JwtKey").ToString();
            _jwtService = jwtService;
        }

        public string Autheticate(string email, string password)
        {
            var userToAuth = _unitOfWork.UserRepository.GetWithInclude(u=>u.Email == email,
                i => i.Roles).FirstOrDefault();

            if (userToAuth == null)
                throw new AuthorizationException(PhotoServiceExceptions.WRONG_CREDENTIALS.GetDescription());

            if (!BCrypt.Net.BCrypt.Verify(password, userToAuth.PasswordHash))
                throw new AuthorizationException(PhotoServiceExceptions.WRONG_CREDENTIALS.GetDescription());

            if (!userToAuth.IsVerified)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_NOT_VERIFIED.GetDescription());

            return _jwtService.CreateToken(key, email, string.Join(",", userToAuth.Roles.Select(x=>x.Title)),userToAuth.UserName);
        }

        public async Task Create(UserRegisterModel newUser)
        {
            var users = _unitOfWork.UserRepository.GetUsers();

            //checking if user already exists
            if (users.FirstOrDefault(x => x.Email == newUser.Email) != null)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_ALREADY_REGISTERED.GetDescription());

            if (users.FirstOrDefault(x => x.UserName == newUser.UserName) != null)
                throw new AuthorizationException(PhotoServiceExceptions.USERNAME_ALREADY_REGISTERED.GetDescription());

            var registeredRole = _unitOfWork.RoleRepository.GetRoleByTitle(UserRoles.REGISTERED_USER.ToString());

            //adding user
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            newUser.IsVerified = false;
            var addedUser = await _unitOfWork.UserRepository.Create(_mapper.Map<User>(newUser));
            await _unitOfWork.SaveAsync();

            //adding roles
            _unitOfWork.UserRepository.AddRole(addedUser, registeredRole);
            await _unitOfWork.SaveAsync();

            //adding default collections
            await AddDefaultCollections(addedUser);
        }

        private async Task AddDefaultCollections(User user)
        {
            _unitOfWork.UserRepository.AddCollection(
                user,
                new Collection {
                    IsPublic = false,
                    Name = "Likes",
                    CollectionAvatarUrl = "/images/collection-images/Heart.png",
                    CollectionType = _unitOfWork.CollectionTypeRepository.GetCollectionTypeByTitle(CollectionTypes.LIKES.ToString())
                }) ;

            _unitOfWork.UserRepository.AddCollection(
               user,
               new Collection
               {
                   IsPublic = false,
                   Name = "Saves",
                   CollectionAvatarUrl = "/images/collection-images/bookmark.png",
                   CollectionType = _unitOfWork.CollectionTypeRepository.GetCollectionTypeByTitle(CollectionTypes.SAVES.ToString())
               });

            await _unitOfWork.SaveAsync();
        }
        public UserModel GetUserByEmail(string email)
        {
            return _mapper.Map<UserModel>(_unitOfWork.UserRepository.GetUser(email: email));
        }

        public UserModel GetUserByUsername(string username)
        {
            return _mapper.Map<UserModel>(_unitOfWork.UserRepository.GetUserByUsername(username));
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserModel>>(_unitOfWork.UserRepository.GetUsers());
        }

        public async Task VerifyUser(string email)
        {
            var user = _unitOfWork.UserRepository.GetWithInclude(u => u.Email == email,
                i => i.Roles).First();

            if (user == null)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_NOT_EXIST.GetDescription());
            if (user.IsVerified)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_ALREADY_VERIFIED.GetDescription());

            var verifiedRole = _unitOfWork.RoleRepository.GetRoleByTitle(UserRoles.VERIFIED_USER.ToString());
            _unitOfWork.UserRepository.AddRole(user, verifiedRole);
            await _unitOfWork.SaveAsync();

            user.IsVerified = true;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
