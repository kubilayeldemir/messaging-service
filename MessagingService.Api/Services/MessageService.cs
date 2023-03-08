using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingService.Api.Persistence.Entities;
using MessagingService.Api.Repositories;
using MessagingService.Api.V1.RequestModels;
using MessagingService.Api.V1.ResponseModels;

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

        public async Task<List<MessageResponse>> GetMessageHistoryWithPartner(string username, long userId, string partnerUsername)
        {
            var partnerUser = await _userRepository.GetUserByUsername(partnerUsername);
            if (partnerUser == null)
            {
                throw new Exception("Partner not found");
            }

            var messages = await _messageRepository.GetMessageHistory(userId, partnerUser.Id);
            return messages.ConvertAll(x => new MessageResponse
            {
                Content = x.Content,
                Id = x.Id,
                ReceiverUserId = x.ReceiverUserId,
                SenderUserId = x.SenderUserId,
                ReceiverUsername = x.ReceiverUserId == userId ? username : partnerUsername,
                SenderUsername = x.SenderUserId == userId ? username : partnerUsername,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();
        }
    }
}