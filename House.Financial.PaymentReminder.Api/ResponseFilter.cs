using Microsoft.AspNetCore.Mvc.Filters;

namespace House.Financial.PaymentReminder.Api
{
    public class ResponseFilter : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var teste = context.HttpContext.Response;
            base.OnResultExecuted(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
