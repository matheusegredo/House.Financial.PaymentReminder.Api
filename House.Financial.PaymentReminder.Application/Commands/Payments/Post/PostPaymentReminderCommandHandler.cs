using House.Financial.PaymentReminder.Application.Commands.Payments.Post;
using House.Financial.PaymentReminder.Data;
using House.Financial.PaymentReminder.Data.Interfaces;

namespace House.Financial.PaymentReminder.Application.Commands
{
    public class PostPaymentReminderCommandHandler : IRequestHandler<PostPaymentReminderCommand, PostPaymentReminderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PostPaymentReminderCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<PostPaymentReminderCommandResponse> Handle(PostPaymentReminderCommand command, CancellationToken cancellationToken)
        {
            await _paymentRepository.AddAsync(_mapper.Map<Payment>(command));
            return new PostPaymentReminderCommandResponse("Payment reminder inserted successfully");
        }        
    }
}
