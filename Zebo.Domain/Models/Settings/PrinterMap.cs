using Zebo.Domain.Models.Menus;
using Zebo.Domain.Models.Tickets;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Settings
{
    public class PrinterMap : ValueClass
    {
        public int PrintJobId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
        public int PrinterId { get; set; }
        public int PrinterTemplateId { get; set; }
    }
}
