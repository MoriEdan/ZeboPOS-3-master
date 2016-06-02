using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Zebo.Domain.Models.Settings;
using Zebo.Localization.Properties;
using Zebo.Modules.SettingsModule.BrowserViews;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Services.Common;

namespace Zebo.Modules.SettingsModule
{
    [ModuleExport(typeof(SettingsModule))]
    public class SettingsModule : ModuleBase
    {
        [ImportingConstructor]
        public SettingsModule()
        {
            AddDashboardCommand<SettingsViewModel>(Resources.LocalSettings, Resources.Settings, 20);
            AddDashboardCommand<TerminalListViewModel>(Resources.Terminals, Resources.Settings, 21);
            AddDashboardCommand<EntityCollectionViewModelBase<NumeratorViewModel, Numerator>>(Resources.Numerators, Resources.Settings, 21);
            AddDashboardCommand<EntityCollectionViewModelBase<ForeignCurrencyViewModel, ForeignCurrency>>(string.Format(Resources.List_f, Resources.Currency), Resources.Settings, 21);
            AddDashboardCommand<EntityCollectionViewModelBase<StateViewModel, State>>(Resources.State.ToPlural(), Resources.Settings, 21);
            AddDashboardCommand<ProgramSettingsViewModel>(Resources.ProgramSettings, Resources.Settings, 22);
            AddDashboardCommand<ZeboPosWebsite>(Resources.ZeboPosWebsite, Resources.ZeboNetwork, 90);
            AddDashboardCommand<ZeboPosDocumentation>(string.Format("ZeboPOS {0}", Resources.Documentation), Resources.ZeboNetwork, 91);
            AddDashboardCommand<ZeboPosForum>(string.Format("ZeboPOS {0}", Resources.Forum), Resources.ZeboNetwork, 92);
            AddDashboardCommand<ZeboPosDevelopment>(string.Format("ZeboPOS {0}", Resources.Development), Resources.ZeboNetwork, 93);
            AddDashboardCommand<ZeboPosWiki>(string.Format("ZeboPOS {0}", Resources.Wiki), Resources.ZeboNetwork, 94);
        }
    }
}
