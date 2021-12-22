using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Profiles;
using House.Financial.PaymentReminder.Data.Interfaces;
using House.Financial.PaymentReminder.Data.Repository;
using MediatR;

namespace House.Financial.PaymentReminder.Api
{
    public static class InjectServices
    {
        public static IServiceCollection InjectHandler(this IServiceCollection services)
        {
            services.AddMediatR(typeof(PostPaymentReminderCommand).Assembly);
            services.AddAutoMapper(typeof(PaymentQueryProfile).Assembly);

            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository>(p => new PaymentRepository("Payments"));

            return services;
        }
    }
}
