using AutoMapper;
using House.Financial.PaymentReminder.Application.Commands;
using House.Financial.PaymentReminder.Application.Commands.Put;
using House.Financial.PaymentReminder.Data;

namespace House.Financial.PaymentReminder.Application.Profiles
{
    public class PaymentCommandProfile : Profile
    {
        public PaymentCommandProfile()
        {
            CreateMap<PostPaymentReminderCommand, Payment>();

            CreateMap<PutPaymentReminderCommand, Payment>();
        }
    }
}
