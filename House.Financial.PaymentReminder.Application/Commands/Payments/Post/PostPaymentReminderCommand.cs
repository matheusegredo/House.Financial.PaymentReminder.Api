using House.Financial.PaymentReminder.Application.Commands.Post;

namespace House.Financial.PaymentReminder.Application.Commands
{
    public class PostPaymentReminderCommand : IRequest<PostPaymentReminderCommandResponse>
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
