using System.Collections.Generic;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Services.Common
{
    public class OrderTagData
    {
        public OrderTagGroup OrderTagGroup { get; set; }
        public OrderTag SelectedOrderTag { get; set; }
        public Ticket Ticket { get; set; }
        public IEnumerable<Order> SelectedOrders { get; set; }
    }
}
