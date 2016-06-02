using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Presentation.Services.Common;
using Zebo.Services.Common;

namespace Zebo.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class LoadTicket : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public LoadTicket(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticketId = actionData.GetAsInteger("TicketId");
            var ticket = _ticketService.OpenTicket(ticketId);
            actionData.DataObject.Ticket = ticket;
            ticket.PublishEvent(EventTopicNames.SetSelectedTicket);
        }

        protected override object GetDefaultData()
        {
            return new { TicketId = 0 };
        }

        protected override string GetActionName()
        {
            return Resources.LoadTicket;
        }

        protected override string GetActionKey()
        {
            return ActionNames.LoadTicket;
        }
    }
}
