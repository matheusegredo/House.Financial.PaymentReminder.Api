using House.Financial.PaymentReminder.Api.Controllers;
using House.Financial.PaymentReminder.Application;
using House.Financial.PaymentReminder.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InjectApplicationDependencies()
    .InjectRepositories()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c => 
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "House.Financial.PaymentReminder.Api", Version = "v1" });
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

new PaymentController(app).InitializeRoutes();

app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "House.Financial.PaymentReminder.Api v1"); });
app.Run();