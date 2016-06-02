using System.ComponentModel;
using Zebo.Domain.Models.Entities;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.Widgets;
using Zebo.Presentation.Services;
using Zebo.Services;

namespace Zebo.Modules.TicketModule.Widgets.TicketExplorer
{
    class TicketExplorerWidgetViewModel : WidgetViewModel
    {
        public TicketExplorerWidgetViewModel(Widget model, IApplicationState applicationState,
             ITicketServiceBase ticketServiceBase, IUserService userService, ICacheService cacheService)
            : base(model, applicationState)
        {
            TicketExplorerViewModel = new TicketExplorerViewModel(ticketServiceBase, userService, cacheService, applicationState);
        }

        [Browsable(false)]
        public TicketExplorerViewModel TicketExplorerViewModel { get; private set; }

        protected override object CreateSettingsObject()
        {
            return null;
        }

        public override void Refresh()
        {
            TicketExplorerViewModel.Refresh();
        }
    }
}
