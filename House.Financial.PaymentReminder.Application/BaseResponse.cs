namespace House.Financial.PaymentReminder.Application
{
    public class BaseResponse
    {
        public BaseResponse(object data, int statusCode = 200)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public BaseResponse(List<ErrorResponse> errors, int statusCode = 500)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public object? Data { get; set; }

        public int StatusCode { get; set; }

        public List<ErrorResponse> Errors { get; set; }
    }

    public class ErrorResponse 
    {
        public string Message { get; set; }

        public string Property { get; set; }
    }
}
