using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Presentation.Services.Common;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UpdateTicketTag : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public UpdateTicketTag(ITicketService ticketService, ICacheService cacheService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null)
            {
                var tagName = actionData.GetAsString("TagName");
                var tagValue = actionData.GetAsString("TagValue");
                _ticketService.UpdateTag(ticket, tagName, tagValue);
            }
        }

        protected override object GetDefaultData()
        {
            return new { TagName = "", TagValue = "" };
        }

        protected override string GetActionName()
        {
            return Resources.UpdateTicketTag;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UpdateTicketTag;
        }
    }
}
