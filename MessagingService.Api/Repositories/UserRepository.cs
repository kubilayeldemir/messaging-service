using System.Threading.Tasks;
using MessagingService.Api.Persistence.Contexts;
using MessagingService.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingService.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<User> GetUserByUsername(string username)
        {
            return _dataContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> CreateUser(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}