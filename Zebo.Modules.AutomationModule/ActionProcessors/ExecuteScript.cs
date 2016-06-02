using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services.Common;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.AutomationModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class ExecuteScript : ActionType
    {
        private readonly IExpressionService _expressionService;

        [ImportingConstructor]
        public ExecuteScript(IExpressionService expressionService)
        {
            _expressionService = expressionService;
        }

        public override void Process(ActionData actionData)
        {
            var script = actionData.GetAsString("ScriptName");
            if (!string.IsNullOrEmpty(script))
            {
                _expressionService.EvalCommand(script, "", actionData.DataObject, true);
            }
        }

        protected override object GetDefaultData()
        {
            return new { ScriptName = "" };
        }

        protected override string GetActionName()
        {
            return Resources.ExecuteScript;
        }

        protected override string GetActionKey()
        {
            return ActionNames.ExecuteScript;
        }
    }
}
