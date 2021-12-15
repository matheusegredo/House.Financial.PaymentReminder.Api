using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Interfaces;
using House.Financial.PaymentReminder.Data.Interfaces;
using House.Financial.PaymentReminder.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services
.AddScoped<IPostPaymentReminderCommandHandler, PostPaymentReminderCommandHandler>()
.AddScoped<IGetPaymentReminderQueryHandler, GetPaymentReminderQueryHandler>()
.AddScoped<IPaymentRepository>(p => new PaymentRepository("Payments"));

var app = builder.Build();

app.MapGet("/", (IGetPaymentReminderQueryHandler handler) => handler.Get());
app.MapGet("/{id}", (int id, IGetPaymentReminderQueryHandler handler) => handler.Get(id));

app.MapPost("/", (PostPaymentReminderCommand command, IPostPaymentReminderCommandHandler handler) => handler.Post(command));

app.Run();
