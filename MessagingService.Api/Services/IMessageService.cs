using System.Threading.Tasks;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.Services
{
    public interface IMessageService
    {
        Task SendMessageToUser(long senderId, SendMessageRequest request);
    }
}