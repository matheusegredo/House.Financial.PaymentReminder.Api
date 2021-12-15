using House.Financial.PaymentReminder.Data;

namespace House.Financial.PaymentReminder.Application.Interfaces
{
    public interface IGetPaymentReminderQueryHandler
    {
        Task<IEnumerable<Payment>> Get();

        Task<Payment> Get(int id);
    }
}
