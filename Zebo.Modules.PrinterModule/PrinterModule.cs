using System.ComponentModel.Composition;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Zebo.Domain.Models.Settings;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Services.Common;

namespace Zebo.Modules.PrinterModule
{
    [ModuleExport(typeof(PrinterModule))]
    class PrinterModule : ModuleBase
    {
        [ImportingConstructor]
        public PrinterModule()
        {
            AddDashboardCommand<EntityCollectionViewModelBase<PrinterViewModel, Printer>>(Resources.Printer.ToPlural(), Resources.Settings, 20);
            AddDashboardCommand<EntityCollectionViewModelBase<PrintJobViewModel, PrintJob>>(Resources.PrintJob.ToPlural(), Resources.Settings, 20);
            AddDashboardCommand<EntityCollectionViewModelBase<PrinterTemplateViewModel, PrinterTemplate>>(Resources.PrinterTemplate.ToPlural(), Resources.Settings, 20);

            HighlightingManager.Instance.RegisterHighlighting("Template", null, () => LoadHighlightingDefinition("Template.xshd"));
        }

        public static IHighlightingDefinition LoadHighlightingDefinition(string resourceName)
        {
            var type = typeof(PrinterModule);
            var fullName = type.Namespace + "." + resourceName;
            using (var stream = type.Assembly.GetManifestResourceStream(fullName))
            using (var reader = new XmlTextReader(stream))
                return HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }
    }
}
