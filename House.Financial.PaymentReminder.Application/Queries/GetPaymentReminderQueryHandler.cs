using House.Financial.PaymentReminder.Application.Interfaces;
using House.Financial.PaymentReminder.Data;
using House.Financial.PaymentReminder.Data.Interfaces;

namespace House.Financial.PaymentReminder.Application.Commands
{
    public class GetPaymentReminderQueryHandler : IGetPaymentReminderQueryHandler
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentReminderQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> Get() => await _paymentRepository.GetAllAsync();

        public async Task<Payment> Get(int id) => await _paymentRepository.GetById(id);        
    }
}
