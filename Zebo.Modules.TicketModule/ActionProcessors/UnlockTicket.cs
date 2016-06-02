using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services.Common;
using Zebo.Services.Common;

namespace Zebo.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UnlockTicket : ActionType
    {
        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null) ticket.UnLock();
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.UnlockTicketRequested);
        }

        protected override object GetDefaultData()
        {
            return new object();
        }

        protected override string GetActionName()
        {
            return Resources.UnlockTicket;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UnlockTicket;
        }
    }
}
