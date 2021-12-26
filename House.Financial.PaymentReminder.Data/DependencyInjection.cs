using House.Financial.PaymentReminder.Data.Interfaces;
using House.Financial.PaymentReminder.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace House.Financial.PaymentReminder.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository>(p => new PaymentRepository("Payments"));

            return services;
        }
    }
}
