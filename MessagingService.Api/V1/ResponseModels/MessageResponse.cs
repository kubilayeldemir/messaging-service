using System;

namespace MessagingService.Api.V1.ResponseModels
{
    public class MessageResponse
    {
        public long Id { get; set; }
        public long SenderUserId { get; set; }
        public long ReceiverUserId { get; set; }
        public string Content { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}