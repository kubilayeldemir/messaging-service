using System.Threading.Tasks;
using MessagingService.Api.Persistence.Entities;

namespace MessagingService.Api.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(Message message);
    }
}