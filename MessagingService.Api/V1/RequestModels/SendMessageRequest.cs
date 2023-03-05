namespace MessagingService.Api.V1.RequestModels
{
    public class SendMessageRequest
    {
        public string ReceiverUsername { get; set; }
        public string Content { get; set; }
    }
}