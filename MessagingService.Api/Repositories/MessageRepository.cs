using System.Threading.Tasks;
using MessagingService.Api.Persistence.Contexts;
using MessagingService.Api.Persistence.Entities;

namespace MessagingService.Api.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _dataContext;

        public MessageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Message> CreateMessage(Message message)
        {
            await _dataContext.Messages.AddAsync(message);
            await _dataContext.SaveChangesAsync();
            return message;
        }
    }
}