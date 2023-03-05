using System.Collections.Generic;
using System.Threading.Tasks;
using MessagingService.Api.Persistence.Entities;

namespace MessagingService.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task<User> CreateUser(User user);
    }
}