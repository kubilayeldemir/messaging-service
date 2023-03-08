using System;
using System.Threading.Tasks;
using MessagingService.Api.Helpers;
using MessagingService.Api.Persistence.Entities;
using MessagingService.Api.Repositories;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool isAuthenticated, User user)> AuthenticateUser(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user is null)
            {
                return (false, null);
            }
            var userSalt = user.Salt;
            var hashedModel = EncryptionHelper.EncryptData(password, userSalt);
            var hashedPassword = hashedModel.hashedData;
            var isCredentialsCorrect = user.CheckIfUserCredentialsCorrect(username, hashedPassword);
            return (isCredentialsCorrect, user);
        }

        public async Task<string> GenerateJwtTokenForUser(User user)
        {
            return JwtHelper.GenerateJwtToken(user);
        }

        public async Task<User> RegisterUser(UserRegisterRequestModel userRegisterModel)
        {
            var (hashedData, salt) = EncryptionHelper.EncryptData(userRegisterModel.Password);
            var user = new User
            {
                Username = userRegisterModel.Username,
                Password = hashedData,
                Salt = salt,
                Role = "user",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            try
            {
                await _userRepository.CreateUser(user);
            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }
    }
}