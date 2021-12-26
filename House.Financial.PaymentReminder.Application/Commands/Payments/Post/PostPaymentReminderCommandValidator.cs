using House.Financial.PaymentReminder.Application.Commands.Payments.Commom;

namespace House.Financial.PaymentReminder.Application.Commands.Post
{
    public class PostPaymentReminderCommandValidator : CommomPaymentReminderCommandValidator<PostPaymentReminderCommand>
    {
        public PostPaymentReminderCommandValidator()
        {
            RuleForName(p => p.Name);
            
            RuleForDate(p => p.Date);

            RuleForValue(p => p.Value);
        }
    }
}
