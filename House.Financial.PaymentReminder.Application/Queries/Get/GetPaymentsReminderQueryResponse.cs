namespace House.Financial.PaymentReminder.Application.Queries.Get
{
    public class GetPaymentsReminderQueryResponse
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public string ExpireDate { get; set; }

        public int DaysLeft { get; set; }
    }
}
