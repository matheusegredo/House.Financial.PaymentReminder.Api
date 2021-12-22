using FluentValidation;

namespace House.Financial.PaymentReminder.Application.Commands.Post
{
    public class PostPaymentReminderCommandValidator : AbstractValidator<PostPaymentReminderCommand>
    {
        public PostPaymentReminderCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.Date)
                .NotEmpty();

            RuleFor(p => p.Value)
                .GreaterThan(0)
                .NotEmpty();                
        }
    }
}
