using House.Financial.PaymentReminder.Api.Infrastrucure.Routes;
using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Commands.Put;
using House.Financial.PaymentReminder.Application.Queries;
using MediatR;

namespace House.Financial.PaymentReminder.Api
{
    public class PaymentController : BaseApiController
    {
        private readonly WebApplication _app;

        public PaymentController(WebApplication app)
        {
            _app = app;
        }

        public void InitializeRoutes()
        {
            _app.MapGet("/", async (HttpContext context, IMediator mediator)
                => await ResponseHandler(context, () => mediator.Send(new GetPaymentReminderQuery())));

            _app.MapGet("/{id}", async (HttpContext context, int id, IMediator mediator)
                => await ResponseHandler(context, () => mediator.Send(new GetPaymentReminderQuery())));

            _app.MapPost("/", async (HttpContext context, PostPaymentReminderCommand command, IMediator mediator)
                => await ResponseHandler(context, () => mediator.Send(command)));

            _app.MapPut("/", async (HttpContext context, PutPaymentReminderCommand command, IMediator mediator)
                => await ResponseHandler(context, () => mediator.Send(command)));
        }
    }    
}
