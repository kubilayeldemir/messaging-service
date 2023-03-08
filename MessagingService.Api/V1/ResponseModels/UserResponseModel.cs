namespace MessagingService.Api.V1.ResponseModels
{
    public class UserResponseModel
    {
        public string Username { get; set; }
        public string Role { get; set; }

        public UserResponseModel()
        {
            
        }
        public UserResponseModel(string username, string role)
        {
            Username = username;
            Role = role;
        }
    }
}