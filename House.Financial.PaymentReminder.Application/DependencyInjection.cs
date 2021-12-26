using FluentValidation;
using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Commands.Post;
using House.Financial.PaymentReminder.Application.Pipelines;
using House.Financial.PaymentReminder.Application.Profiles.Query;
using Microsoft.Extensions.DependencyInjection;

namespace House.Financial.PaymentReminder.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(PostPaymentReminderCommand).Assembly);
            services.AddAutoMapper(typeof(PaymentQueryProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(PostPaymentReminderCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorRequestBehavior<,>));

            return services;
        }
    }
}
