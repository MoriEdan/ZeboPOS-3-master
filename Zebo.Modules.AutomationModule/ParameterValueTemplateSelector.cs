using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zebo.Presentation.Services.Common;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.AutomationModule
{
    public class ParameterValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ValueTemplate { get; set; }
        public DataTemplate PasswordTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var pv = item as ParameterValue;
            if (pv != null)
            {
                if (pv.Name.Contains("Password")) return PasswordTemplate;
                if (pv.Values.Any()) return ValueTemplate;
            }
            return TextTemplate;
        }
    }
}