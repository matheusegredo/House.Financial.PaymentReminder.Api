using AutoMapper;
using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Commands.Payments.Post;
using House.Financial.PaymentReminder.Application.Profiles;
using House.Financial.PaymentReminder.Application.Test.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace House.Financial.PaymentReminder.Application.Test.Command.Payments
{
    [Trait("Payment", "Post")]
    public class PostPaymentReminderCommandTest
    {
        private readonly PostPaymentReminderCommandHandler _handler;

        public PostPaymentReminderCommandTest()
        {
            var repository = new MockPaymentRepository().Mock();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PaymentCommandProfile())).CreateMapper();

            _handler = new PostPaymentReminderCommandHandler(mapper, repository);
        }

        [Fact(DisplayName = "Handler should return PostPaymentReminderCommandResponse")]
        public async Task PostCompleted_ShouldReturnPostPaymentReminderCommandResponse()
        {
            var command = new PostPaymentReminderCommand();

            Assert.IsAssignableFrom<PostPaymentReminderCommandResponse>(await _handler.Handle(command, default));
        }
    }
}
