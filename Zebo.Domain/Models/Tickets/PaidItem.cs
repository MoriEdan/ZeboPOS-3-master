using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Tickets
{
    public class PaidItem : ValueClass
    {
        public string Key { get; set; }
        public decimal Quantity { get; set; }
        public int TicketId { get; set; }
    }
}
