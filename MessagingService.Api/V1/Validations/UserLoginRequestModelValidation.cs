using FluentValidation;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.V1.Validations
{
    public class UserLoginRequestModelValidation : AbstractValidator<UserLoginRequestModel>
    {
        public UserLoginRequestModelValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}