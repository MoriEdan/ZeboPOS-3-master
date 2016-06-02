using System.ComponentModel.Composition;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class ChangePaymentValueChanger : AbstractValueChanger<ChangePayment>
    {
        public override string GetTargetTag()
        {
            return "CHANGES";
        }

        protected override string GetModelName(ChangePayment model)
        {
            return model.Name;
        }
    }
}
