using System.ComponentModel.Composition;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class PaymentValueChanger : AbstractValueChanger<Payment>
    {
        public override string GetTargetTag()
        {
            return "PAYMENTS";
        }

        protected override string GetModelName(Payment model)
        {
            return model.Name;
        }
    }
}
