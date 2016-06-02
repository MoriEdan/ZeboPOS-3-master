using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Presentation.Services.Common;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UntagOrder : OrderTagOperation
    {
        [ImportingConstructor]
        public UntagOrder(ICacheService cacheService, ITicketService ticketService)
            : base(cacheService, ticketService)
        {
        }

        protected override string GetActionName()
        {
            return Resources.UntagOrder;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UntagOrder;
        }

        protected override object GetDefaultData()
        {
            return new { OrderTagName = "", OrderTagValue = "" };
        }
    }
}
