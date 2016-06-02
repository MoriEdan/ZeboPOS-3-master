using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using Zebo.Domain.Models.Tickets;
using Zebo.Presentation.Services.Common;

namespace Zebo.Modules.PosModule
{
    /// <summary>
    /// Interaction logic for TicketOrdersView.xaml
    /// </summary>
    [Export]
    public partial class TicketOrdersView : UserControl
    {
        [ImportingConstructor]
        public TicketOrdersView(TicketOrdersViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();

            EventServiceFactory.EventService.GetEvent<GenericEvent<Order>>().Subscribe(
               x =>
               {
                   if (x.Topic == EventTopicNames.OrderAdded)
                       Scroller.ScrollToEnd();
               });


            EventServiceFactory.EventService.GetEvent<GenericEvent<EventAggregator>>().Subscribe(
                x =>
                {
                    if (x.Topic == EventTopicNames.ActivatePosView && !((TicketOrdersViewModel)DataContext).SelectedOrders.Any())
                    {
                        Scroller.ScrollToEnd();
                    }
                });
        }
    }
}
