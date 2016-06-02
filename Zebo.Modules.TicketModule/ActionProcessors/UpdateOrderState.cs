using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Presentation.Services.Common;
using Zebo.Services.Common;

namespace Zebo.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UpdateOrderState : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public UpdateOrderState(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            var orders = Helper.GetOrders(actionData, ticket);
            if (orders.Any())
            {
                var stateName = actionData.GetAsString("StateName");
                var currentState = actionData.GetAsString("CurrentState");
                var groupOrder = actionData.GetAsInteger("GroupOrder");
                var state = actionData.GetAsString("State");
                var stateOrder = actionData.GetAsInteger("StateOrder");
                var stateValue = actionData.GetAsString("StateValue");
                _ticketService.UpdateOrderStates(ticket, orders.ToList(), stateName, currentState, groupOrder, state, stateOrder, stateValue);
            }
        }

        protected override object GetDefaultData()
        {
            return new { StateName = "", GroupOrder = 0, CurrentState = "", State = "", StateOrder = 0, StateValue = "" };
        }

        protected override string GetActionName()
        {
            return Resources.UpdateOrderState;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UpdateOrderState;
        }
    }
}
