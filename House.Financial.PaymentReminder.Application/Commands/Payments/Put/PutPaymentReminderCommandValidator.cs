using FluentValidation;
using House.Financial.PaymentReminder.Application.Commands.Payments.Commom;

namespace House.Financial.PaymentReminder.Application.Commands.Put
{
    public class PutPaymentReminderCommandValidator : CommomPaymentReminderCommandValidator<PutPaymentReminderCommand>
    {
        public PutPaymentReminderCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty();

            RuleForName(p => p.Name);

            RuleForDate(p => p.Date);

            RuleForValue(p => p.Value);
        }
    }
}
