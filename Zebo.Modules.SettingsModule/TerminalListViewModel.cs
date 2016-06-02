using System.ComponentModel.Composition;
using Zebo.Domain.Models.Settings;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.SettingsModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class TerminalListViewModel : EntityCollectionViewModelBase<TerminalViewModel, Terminal>
    {
        protected override string CanDeleteItem(Terminal model)
        {
            var count = Workspace.Count<Terminal>();
            if (count == 1) return Resources.DeleteErrorShouldHaveAtLeastOneTerminal;
            return base.CanDeleteItem(model);
        }
    }
}
