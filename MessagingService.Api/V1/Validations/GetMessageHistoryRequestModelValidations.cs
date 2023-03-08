using FluentValidation;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.V1.Validations
{
    public class GetMessageHistoryRequestModelValidations  : AbstractValidator<GetMessageHistoryRequestModel>
    {
        public GetMessageHistoryRequestModelValidations()
        {
            RuleFor(x => x.PartnerUsername).NotEmpty().WithMessage("Partner username cannot be empty");
            RuleFor(x => x.PartnerUsername).MinimumLength(3).WithMessage("Partner username too short");
        }
    }
}