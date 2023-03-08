using System.Collections.Generic;
using System.Threading.Tasks;
using MessagingService.Api.V1.RequestModels;
using MessagingService.Api.V1.ResponseModels;

namespace MessagingService.Api.Services
{
    public interface IMessageService
    {
        Task SendMessageToUser(long senderId, SendMessageRequest request);
        Task<List<MessageResponse>> GetMessageHistoryWithPartner(string username, long userId, string partnerUsername);
    }
}