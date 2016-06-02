using System.ComponentModel.Composition;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class OrderStateValueChanger : AbstractValueChanger<OrderStateValue>
    {
        public override string GetTargetTag()
        {
            return "ORDER STATES";
        }

        protected override string GetModelName(OrderStateValue model)
        {
            return model.StateValue;
        }
    }
}
