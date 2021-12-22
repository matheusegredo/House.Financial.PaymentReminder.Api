using AutoMapper;
using House.Financial.PaymentReminder.Application.Queries;
using House.Financial.PaymentReminder.Data;

namespace House.Financial.PaymentReminder.Application.Profiles
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
