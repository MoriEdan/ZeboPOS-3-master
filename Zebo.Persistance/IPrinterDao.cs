using System.Collections.Generic;
using Zebo.Domain.Models.Settings;

namespace Zebo.Persistance
{
    public interface IPrinterDao
    {
        IEnumerable<Printer> GetPrinters();
        IEnumerable<PrinterTemplate> GetPrinterTemplates();
    }
}
