using House.Financial.PaymentReminder.Application.Commands.Payments.Put;

namespace House.Financial.PaymentReminder.Application.Commands.Put
{
    public class PutPaymentReminderCommand : IRequest<PutPaymentReminderCommandResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
