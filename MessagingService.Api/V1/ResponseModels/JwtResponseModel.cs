using MessagingService.Api.Persistence.Entities;

namespace MessagingService.Api.V1.ResponseModels
{
    public class JwtResponseModel
    {
        public UserResponseModel User { get; set; }
        public string Jwt { get; set; }

        public JwtResponseModel(User user, string jwt)
        {
            User = new UserResponseModel(user.Username, user.Role);
            Jwt = "Bearer " + jwt;
        }
    }
}