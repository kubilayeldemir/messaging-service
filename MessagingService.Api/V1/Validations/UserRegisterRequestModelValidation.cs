using FluentValidation;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.V1.Validations
{
    public class UserRegisterRequestModelValidation : AbstractValidator<UserRegisterRequestModel>
    {
        public UserRegisterRequestModelValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(x => x.Username).MaximumLength(32).WithMessage("Username cannot be larger than 32 chars.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Username too short.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Password cannot be smaller than 4 chars.");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Password cannot be larger than 50 chars.");
        }
    }
}