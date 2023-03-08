using FluentValidation;
using MessagingService.Api.V1.RequestModels;

namespace MessagingService.Api.V1.Validations
{
    public class SendMessageRequestModelValidation : AbstractValidator<SendMessageRequest>
    {
        public SendMessageRequestModelValidation()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Message content cannot be empty");
            RuleFor(x => x.ReceiverUsername).NotEmpty().WithMessage("Receiver Username content cannot be empty");
            RuleFor(x => x.Content).MaximumLength(10000).WithMessage("Message cannot be larger than 10000 chars.");
        }
    }
}