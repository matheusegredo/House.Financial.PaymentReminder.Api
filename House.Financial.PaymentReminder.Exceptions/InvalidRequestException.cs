namespace House.Financial.PaymentReminder.Exceptions
{
    public class InvalidRequestException : Exception
    {        
        public InvalidRequestException(string message) : base(message)
        {
        }
    }
}
