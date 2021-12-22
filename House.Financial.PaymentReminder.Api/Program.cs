using House.Financial.PaymentReminder.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InjectHandler()
    .InjectRepositories()
    .AddScoped<ResponseFilter>()
    .AddControllersWithViews(options => 
    {
        options.Filters.Add(new ResponseFilter());
    });


var app = builder.Build();

new ConfigureRoutes(app).InitializeComponents();

app.MapControllers();
app.Run();