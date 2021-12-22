﻿using House.Financial.PaymentReminder.Application;
using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Commands.Put;
using House.Financial.PaymentReminder.Application.Queries;
using House.Financial.PaymentReminder.Exceptions;
using MediatR;

namespace House.Financial.PaymentReminder.Api
{
    public class ConfigureRoutes
    {
        private readonly WebApplication _app;

        public ConfigureRoutes(WebApplication app)
        {
            _app = app;
        }

        public void InitializeComponents()
        {
            Get();
            GetById();
            Post();
            Put();
        }

        public void Get() => _app.MapGet("/", async (HttpContext context, IMediator mediator) => await ResponseHandler(context, () => mediator.Send(new GetPaymentReminderQuery())));

        public void GetById() => _app.MapGet("/{id}", async (HttpContext context, int id, IMediator mediator) => await ResponseHandler(context, () => mediator.Send(new GetPaymentReminderQuery())));

        public void Post() => _app.MapPost("/", async (HttpContext context, PostPaymentReminderCommand command, IMediator mediator) => await ResponseHandler(context, () => mediator.Send(command)));

        public void Put() => _app.MapPut("/", async (HttpContext context, PutPaymentReminderCommand command, IMediator mediator) => await ResponseHandler(context, () => mediator.Send(command)));

        private static async Task<IResult> ResponseHandler<TDataObject>(HttpContext context, Func<Task<TDataObject>> func) 
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
                    _ => PrepareObjectResultWithErrors(ex, 500)
                };
            }            
        }

        private static IResult PrepareObjectResultWithErrors(Exception ex, int statusCode) 
        {
            var baseResponse = new BaseResponse(new List<ErrorResponse> { new ErrorResponse { Message = ex.Message } }, statusCode);

            return statusCode switch
            {
                400 => Results.BadRequest(baseResponse),
                404 => Results.NotFound(baseResponse),
                _ => Results.Json(baseResponse, statusCode: statusCode)
            };
        }
    }    
}
