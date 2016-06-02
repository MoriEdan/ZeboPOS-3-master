using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Threading;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Services.Common;

namespace Zebo.Presentation.Controls.ActionProcessors
{
    [Export(typeof(IActionType))]
    class ShowMessage : ActionType
    {
        private readonly IUserInteraction _userInteraction;

        [ImportingConstructor]
        public ShowMessage(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public override void Process(ActionData actionData)
        {
            var param = actionData.GetAsString("Message");
            if (!string.IsNullOrEmpty(param))
                _userInteraction.GiveFeedback(param);
        }

        protected override object GetDefaultData()
        {
            return new { Message = "" };
        }

        protected override string GetActionName()
        {
            return Resources.ShowMessage;
        }

        protected override string GetActionKey()
        {
            return "ShowMessage";
        }
    }
}
