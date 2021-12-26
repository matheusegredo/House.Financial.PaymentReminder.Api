using House.Financial.PaymentReminder.Application.Queries.Get;
using House.Financial.PaymentReminder.Data.Entities;

namespace House.Financial.PaymentReminder.Application.Profiles.Query
{
    public class PaymentQueryProfile : Profile
    {
        public PaymentQueryProfile()
        {
            CreateMap<Payment, GetPaymentsReminderQueryResponse>()
                .ForMember(dest => dest.ExpireDate, o => o.MapFrom(src => src.Date.ToShortDateString()))
                .ForMember(dest => dest.DaysLeft, o => o.MapFrom(src => src.Date.DayOfYear - DateTime.Now.DayOfYear));
        }
    }
}
