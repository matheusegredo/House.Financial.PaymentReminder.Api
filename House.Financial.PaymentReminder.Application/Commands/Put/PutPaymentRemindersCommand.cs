namespace House.Financial.PaymentReminder.Application.Commands.Put
{
    public class PutPaymentRemindersCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
