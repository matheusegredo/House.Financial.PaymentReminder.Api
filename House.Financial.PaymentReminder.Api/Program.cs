using House.Financial.PaymentReminder.Api;
using House.Financial.PaymentReminder.Application;
using House.Financial.PaymentReminder.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InjectApplicationDependencies()
    .InjectRepositories();

var app = builder.Build();

new PaymentController(app).InitializeRoutes();

app.Run();