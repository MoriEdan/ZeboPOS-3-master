using Zebo.Domain.Models.Tickets;

namespace Zebo.Modules.PaymentModule
{
    public class PaymentData
    {
        public PaymentType PaymentType { get; set; }
        public ChangePaymentType ChangePaymentType { get; set; }
        public decimal PaymentDueAmount { get; set; }
        public decimal TenderedAmount { get; set; }
    }
}