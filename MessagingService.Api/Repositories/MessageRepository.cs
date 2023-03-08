using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingService.Api.Persistence.Contexts;
using MessagingService.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Message>> GetMessageHistory(long userId, long partnerUserId)
        {
            var messages = await _dataContext.Messages.Where(m =>
                m.SenderUserId == userId && m.ReceiverUserId == partnerUserId ||
                m.SenderUserId == partnerUserId && m.ReceiverUserId == userId).ToListAsync();
            return messages;
        }
    }
}