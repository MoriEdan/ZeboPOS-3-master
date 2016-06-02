using System;
using System.Windows.Documents;
using System.Windows.Media;
using Zebo.Domain.Models.Settings;
using Zebo.Services.Implementations.PrinterModule.Formatters;
using Zebo.Services.Implementations.PrinterModule.Tools;

namespace Zebo.Services.Implementations.PrinterModule.PrintJobs
{
    public class RawPrinterJob : AbstractPrintJob
    {
        public RawPrinterJob(Printer printer)
            : base(printer)
        {

        }

        public override void DoPrint(string[] lines)
        {
            var text = string.Join(Environment.NewLine, lines);
            RawPrinterHelper.SendStringToPrinter(Printer.ShareName, text+Environment.NewLine);
        }

        public override void DoPrint(FlowDocument document)
        {
            return;
        }
    }
}