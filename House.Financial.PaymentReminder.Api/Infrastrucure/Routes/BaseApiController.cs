using FluentValidation;
using House.Financial.PaymentReminder.Exceptions;

namespace House.Financial.PaymentReminder.Api.Infrastrucure.Routes
{
    public class BaseApiController
    {
        protected static async Task<IResult> ResponseHandler<TDataObject>(HttpContext context, Func<Task<TDataObject>> func)
        {
            try
            {
                var response = await func();

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return ex switch
                {
                    InvalidRequestException invalid => PrepareObjectResultWithErrors(invalid, 400),
                    NotFoundException notFound => PrepareObjectResultWithErrors(notFound, 404),
                    ValidationException validation => PrepareValidationResultWithErrors(validation),
                    _ => PrepareObjectResultWithErrors(ex, 500)
                };
            }
        }

        private static IResult PrepareObjectResultWithErrors(Exception ex, int statusCode)
        {
            var baseResponse = new BaseApiResponse(new List<ErrorResponse> { new ErrorResponse { Message = ex.Message } }, statusCode);

            return statusCode switch
            {
                400 => Results.BadRequest(baseResponse),
                404 => Results.NotFound(baseResponse),
                _ => Results.Json(baseResponse, statusCode: statusCode)
            };
        }

        private static IResult PrepareValidationResultWithErrors(ValidationException ex) 
        {
            var errorResponse = ex.Errors.Select(p => new ErrorResponse { Message = p.ErrorMessage, Property = p.PropertyName }).ToList();

            return Results.BadRequest(new BaseApiResponse(errorResponse, 400));
        }
    }
}
