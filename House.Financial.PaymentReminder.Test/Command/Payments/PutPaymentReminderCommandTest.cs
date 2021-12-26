using AutoMapper;
using House.Financial.PaymentReminder.Application.Commands.Payments.Put;
using House.Financial.PaymentReminder.Application.Commands.Put;
using House.Financial.PaymentReminder.Application.Profiles;
using House.Financial.PaymentReminder.Application.Test.Repositories;
using House.Financial.PaymentReminder.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace House.Financial.PaymentReminder.Application.Test.Command.Payments
{
    [Trait("Payment", "Put")]
    public class PutPaymentReminderCommandTest
    {
        private readonly PutPaymentReminderCommandHandler _handler;

        public PutPaymentReminderCommandTest()
        {
            var repository = new MockPaymentRepository().Mock();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PaymentCommandProfile())).CreateMapper();

            _handler = new PutPaymentReminderCommandHandler(mapper, repository);
        }

        [Fact(DisplayName = "Handler should return PutPaymentReminderCommandResponse")]
        public async Task PutCompleted_ShouldReturnPutPaymentReminderCommandResponse()
        {
            var command = new PutPaymentReminderCommand { Id = 1 };

            Assert.IsType<PutPaymentReminderCommandResponse>(await _handler.Handle(command, default));
        }

        [Fact(DisplayName = "Put a nonexisting payment reminder should throw NotFoundException")]
        public async Task PutNonExistingPaymentCompleted_ShouldThrowsNotFoundException()
        {
            var command = new PutPaymentReminderCommand { Id = 999 };

            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, default));
        }
    }
}
