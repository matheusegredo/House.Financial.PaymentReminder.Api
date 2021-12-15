using House.Financial.PaymentReminder.Application.Interfaces;
using House.Financial.PaymentReminder.Data;
using House.Financial.PaymentReminder.Data.Interfaces;

namespace House.Financial.PaymentReminder.Application.Commands
{
    public class PostPaymentReminderCommandHandler : IPostPaymentReminderCommandHandler
    {
        private readonly IPaymentRepository _paymentRepository;

        public PostPaymentReminderCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<string> Post(PostPaymentReminderCommand command)
        {
            await _paymentRepository.AddAsync(new Payment { Name = command.Name, Value = command.Value, Date = command.Date });

            return $"{command.Name} added successfuly.";
        }
    }
}
