using AutoMapper;
using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Profiles;
using House.Financial.PaymentReminder.Data.Interfaces;
using MediatR;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace House.Financial.PaymentReminder.Application.Test.Command
{
    [Trait("Payment", "Post")]
    public class PostPaymentReminderCommandTest
    {
        private readonly PostPaymentReminderCommandHandler _handler;

        public PostPaymentReminderCommandTest()
        {
            var repository = new Mock<IPaymentRepository>().Object;
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PaymentCommandProfile())).CreateMapper();

            _handler = new PostPaymentReminderCommandHandler(mapper, repository);
        }

        [Fact(DisplayName = "Handler should return unit")]
        public async Task PostCompleted_ShouldReturnUnit() 
        {
            var command = new PostPaymentReminderCommand();

            Assert.IsAssignableFrom<Unit>(await _handler.Handle(command, default));
        }
    }
}
