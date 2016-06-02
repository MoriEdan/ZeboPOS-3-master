using System;
using Zebo.Domain.Models.Settings;

namespace Zebo.Services.Implementations.PrinterModule
{
    public interface IDocumentFormatter
    {
        Type ObjectType { get; }
        string[] GetFormattedDocument(object item, PrinterTemplate printerTemplate);
    }
}