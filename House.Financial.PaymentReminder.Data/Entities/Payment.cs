namespace House.Financial.PaymentReminder.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
