using System;
using System.Threading.Tasks;
using MessagingService.Api.Persistence.Entities;
using MessagingService.Api.Repositories;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }
        
        public async Task SendMessageToUser(long senderId, SendMessageRequest request)
        {
            var receiverUser = await _userRepository.GetUserByUsername(request.ReceiverUsername);
            if (receiverUser == null)
            {
                throw new Exception("User not found");
            }
            
            await _messageRepository.CreateMessage(new Message
            {
                Content = request.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                SenderUserId = senderId,
                ReceiverUserId = receiverUser.Id
            });
        }
    }
}