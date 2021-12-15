using House.Financial.PaymentReminder.Application.Commands;

namespace House.Financial.PaymentReminder.Application.Interfaces
{
    public interface IPostPaymentReminderCommandHandler
    {
        Task<string> Post(PostPaymentReminderCommand command);
    }
}
