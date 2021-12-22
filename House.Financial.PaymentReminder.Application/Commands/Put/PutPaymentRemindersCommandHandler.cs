﻿using House.Financial.PaymentReminder.Data;
using House.Financial.PaymentReminder.Data.Interfaces;
using House.Financial.PaymentReminder.Exceptions;

namespace House.Financial.PaymentReminder.Application.Commands.Put
{
    public class PutPaymentRemindersCommandHandler : IRequestHandler<PutPaymentReminderCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PutPaymentRemindersCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(PutPaymentReminderCommand command, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetById(command.Id);

            if (payment is null)
                throw new NotFoundException("Payment not found.");

            await _paymentRepository.UpdateAsync(payment, command.Id);

            return Unit.Value;
        }
    }
}
