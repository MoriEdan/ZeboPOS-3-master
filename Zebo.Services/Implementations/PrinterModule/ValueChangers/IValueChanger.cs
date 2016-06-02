using System.Collections.Generic;
using Zebo.Domain.Models.Settings;

namespace Zebo.Services.Implementations.PrinterModule.ValueChangers
{
    interface IValueChanger<in T>
    {
        string Replace(PrinterTemplate template, string content, IEnumerable<T> models);
        string GetValue(PrinterTemplate template, T model);
    }
}
