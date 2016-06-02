using System.ComponentModel.Composition;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.Commands;
using Zebo.Presentation.Services.Common;

namespace Zebo.Modules.ModifierModule
{
    [Export]
    public class TicketNoteEditorViewModel : ObservableObject
    {
        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                RaisePropertyChanged(() => SelectedTicket);
            }
        }

        public ICaptionCommand CloseCommand { get; set; }

        public TicketNoteEditorViewModel()
        {
            CloseCommand = new CaptionCommand<string>(Resources.Close, OnClose);
        }

        private void OnClose(string obj)
        {
            SelectedTicket = null;
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.ActivatePosView);
        }
    }
}
