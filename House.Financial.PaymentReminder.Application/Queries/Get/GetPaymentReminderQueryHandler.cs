using AutoMapper;
using House.Financial.PaymentReminder.Application.Queries;
using House.Financial.PaymentReminder.Data.Interfaces;

namespace House.Financial.PaymentReminder.Application.Commands
{
    public class GetPaymentReminderQueryHandler : IRequestHandler<GetPaymentReminderQuery, List<GetPaymentsReminderQueryResponse>>
    {
        private IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentReminderQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<List<GetPaymentsReminderQueryResponse>> Handle(GetPaymentReminderQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetAllAsync();

            return _mapper.Map<List<GetPaymentsReminderQueryResponse>>(payments);
        }
    }
}
