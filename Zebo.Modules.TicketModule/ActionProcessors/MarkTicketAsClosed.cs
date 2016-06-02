using System.ComponentModel.Composition;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services.Common;
using Zebo.Services.Common;

namespace Zebo.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class MarkTicketAsClosed : ActionType
    {
        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null) ticket.Close();
        }

        protected override object GetDefaultData()
        {
            return new object();
        }

        protected override string GetActionName()
        {
            return Resources.MarkTicketAsClosed;
        }

        protected override string GetActionKey()
        {
            return ActionNames.MarkTicketAsClosed;
        }
    }
}
