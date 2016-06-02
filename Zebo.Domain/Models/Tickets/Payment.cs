using System;
using Zebo.Domain.Models.Accounts;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Tickets
{
    public class Payment : ValueClass
    {
        public Payment()
        {
            Date = DateTime.Now;
        }

        public int PaymentTypeId { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int AccountTransactionId { get; set; }
        public virtual AccountTransaction AccountTransaction { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
