using House.Financial.PaymentReminder.Data.Interfaces;

namespace House.Financial.PaymentReminder.Application.Commands.Put
{
    public class PutPaymentRemindersCommandHandler : IRequestHandler<PutPaymentRemindersCommand, Unit>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PutPaymentRemindersCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<Unit> Handle(PutPaymentRemindersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> Put(PostPaymentReminderCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
