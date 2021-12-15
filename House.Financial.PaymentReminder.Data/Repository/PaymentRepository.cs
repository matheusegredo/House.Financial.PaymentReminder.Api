#pragma warning disable CS8603 // Possível retorno de referência nula.
using House.Financial.PaymentReminder.Data.Interfaces;

namespace House.Financial.PaymentReminder.Data.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(string tableName) : base(tableName)
        {
        }

        public override string Identifier => "Id";       
    }
}
