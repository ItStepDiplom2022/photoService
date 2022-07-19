using AutoMapper;
using Microsoft.Extensions.Configuration;
using PhotoService.BLL.Enums;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;

namespace PhotoService.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly string key;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            key = configuration.GetSection("JwtKey").ToString();
            _jwtService = jwtService;
        }

        public string Autheticate(string email, string password)
        {
            var userToAuth = _userRepository.GetUser(email);

            if (userToAuth == null)
                throw new AuthorizationException(PhotoServiceExceptions.WRONG_CREDENTIALS.GetDescription());

            if (!BCrypt.Net.BCrypt.Verify(password, userToAuth.Password))
                throw new AuthorizationException(PhotoServiceExceptions.WRONG_CREDENTIALS.GetDescription());

            if (!userToAuth.IsVerified)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_NOT_VERIFIED.GetDescription());

            return _jwtService.CreateToken(key, email, string.Join(",", userToAuth.Roles));
        }

        public void Create(UserRegisterModel newUser)
        {
            var users = _userRepository.GetUsers();

            //checking if user already exists
            if (users.FirstOrDefault(x => x.Email == newUser.Email) != null)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_ALREADY_REGISTERED.GetDescription());

            if (users.FirstOrDefault(x => x.UserName == newUser.UserName) != null)
                throw new AuthorizationException(PhotoServiceExceptions.USERNAME_ALREADY_REGISTERED.GetDescription());

            (newUser.Roles as List<string>).Add(UserRoles.REGISTERED_USER.ToString());
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            newUser.IsVerified = false;
            _userRepository.Create(_mapper.Map<User>(newUser));
        }

        public Task<UserModel> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void VerifyUser(string email)
        {
            var user = _userRepository.GetUser(email);

            if (user == null)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_NOT_EXIST.GetDescription());
            if (user.IsVerified)
                throw new AuthorizationException(PhotoServiceExceptions.EMAIL_ALREADY_VERIFIED.GetDescription());

            (user.Roles as List<string>).Add(UserRoles.VERIFIED_USER.ToString());
            user.IsVerified = true;
            _userRepository.Update(user);
        }
    }
}
