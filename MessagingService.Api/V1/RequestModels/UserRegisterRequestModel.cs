namespace MessagingService.Api.V1.RequestModels
{
    public class UserRegisterRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}