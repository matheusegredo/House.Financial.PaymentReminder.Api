namespace House.Financial.PaymentReminder.Application.Commands
{
    public class BaseCommandResponse
    {
        public BaseCommandResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }        
    }
}
