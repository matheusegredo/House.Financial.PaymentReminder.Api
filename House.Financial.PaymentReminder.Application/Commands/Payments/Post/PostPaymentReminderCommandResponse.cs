namespace House.Financial.PaymentReminder.Application.Commands.Post
{
    public class PostPaymentReminderCommandResponse
    {
        public PostPaymentReminderCommandResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
