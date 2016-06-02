using Zebo.Domain.Models.Settings;

namespace Zebo.Services.Implementations.PrinterModule
{
    public class TicketPrintTask
    {
        public Printer Printer { get; set; }
        public string[] Lines { get; set; }
    }
}