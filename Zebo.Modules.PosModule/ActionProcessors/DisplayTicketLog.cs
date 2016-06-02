using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services.Common;
using Zebo.Services.Common;

namespace Zebo.Modules.PosModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class DisplayTicketLog : ActionType
    {
        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null)
            {
                ticket.PublishEvent(EventTopicNames.DisplayTicketLog);
            }
        }

        protected override object GetDefaultData()
        {
            return null;
        }

        protected override string GetActionName()
        {
            return Resources.DisplayTicketLog;
        }

        protected override string GetActionKey()
        {
            return "DisplayTicketLog";
        }
    }
}
