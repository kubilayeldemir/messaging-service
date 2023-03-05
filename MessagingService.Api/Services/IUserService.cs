using System.Threading.Tasks;
using MessagingService.Api.Persistence.Entities;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.Services
{
    public interface IUserService
    {
        Task<(bool isAuthenticated,User user)> AuthenticateUser(string username, string password);
        Task<string> GenerateJwtTokenForUser(User user);
        Task<User> RegisterUser(UserRegisterRequestModel userRegisterModel);
    }
}