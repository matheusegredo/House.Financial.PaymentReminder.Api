using AutoMapper;
using House.Financial.PaymentReminder.Application.Profiles;
using House.Financial.PaymentReminder.Application.Queries;
using House.Financial.PaymentReminder.Application.Queries.Get;
using House.Financial.PaymentReminder.Application.Test.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace House.Financial.PaymentReminder.Application.Test.Queries
{
    [Trait("Payment", "Get")]
    public class GetPaymentReminderQueryTest
    {
        private readonly GetPaymentReminderQueryHandler _handler;

        public GetPaymentReminderQueryTest()
        {
            var repository = new MockPaymentRepository().Mock();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new PaymentQueryProfile())).CreateMapper();

            _handler = new GetPaymentReminderQueryHandler(mapper, repository);
        }

        [Fact(DisplayName = "Handler should return a list of Payments")]
        public async Task GetAll_ShouldReturnListOfPayments()
        {
            var command = new GetPaymentReminderQuery();

            Assert.NotEmpty(await _handler.Handle(command, default));
        }
    }
}
