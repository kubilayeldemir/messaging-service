using System.Collections.Generic;
using System.Threading.Tasks;
using MessagingService.Api.Persistence.Entities;

namespace MessagingService.Api.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(Message message);
        Task<List<Message>> GetMessageHistory(long userId, long partnerUserId);
    }
}