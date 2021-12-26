using FluentValidation;
using System.Linq.Expressions;

namespace House.Financial.PaymentReminder.Application.Commands.Payments.Commom
{
    public class CommomPaymentReminderCommandValidator<T> : AbstractValidator<T>
    {
        protected void RuleForName(Expression<Func<T, string>> expression) =>        
            RuleFor(expression)
                .NotEmpty();

        protected void RuleForDate(Expression<Func<T, DateTime>> expression) =>       
            RuleFor(expression)
                .NotEmpty();

        protected void RuleForValue(Expression<Func<T, decimal>> expression) =>
            RuleFor(expression)
                .GreaterThan(0)
                .NotEmpty();
    }
}
