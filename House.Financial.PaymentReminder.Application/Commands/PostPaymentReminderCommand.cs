namespace House.Financial.PaymentReminder.Application.Commands
{
    public class PostPaymentReminderCommand
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
