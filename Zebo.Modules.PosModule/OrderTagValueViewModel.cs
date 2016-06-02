using System.Linq;
using Zebo.Domain.Models.Tickets;
using Zebo.Presentation.Common;

namespace Zebo.Modules.PosModule
{
    public class OrderTagValueViewModel : ObservableObject
    {
        public OrderTagValue Model { get; set; }

        public OrderTagValueViewModel(OrderTagValue model)
        {
            Model = model;
        }

        public string DisplayString
        {
            get
            {
                if (Model.Quantity > 1)
                    return Model.TagValue + " x " + Model.Quantity.ToString("#");
                return Model.TagValue;
            }
        }

        public string PriceString
        {
            get
            {
                return Model.Price != 0 && !Model.AddTagPriceToOrderPrice ? ((Model.Price) * Model.Quantity).ToString("#,#0.00") : "";
            }
        }

        public string ShortName { get { return Model.ShortName; } }
    }
}
