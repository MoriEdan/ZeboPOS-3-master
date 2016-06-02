﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.AccountModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class PrintAccountScreen : ActionType
    {
        private readonly IReportServiceClient _reportServiceClient;
        private readonly ICacheService _cacheService;

        [ImportingConstructor]
        public PrintAccountScreen(IReportServiceClient reportServiceClient, ICacheService cacheService)
        {
            _reportServiceClient = reportServiceClient;
            _cacheService = cacheService;
        }

        public override void Process(ActionData actionData)
        {
            var screenName = actionData.GetAsString("AccountScreenName");
            var screen = _cacheService.GetAccountScreens().FirstOrDefault(x => x.Name == screenName);
            if (screen != null)
            {
                _reportServiceClient.PrintAccountScreen(screen);
            }
        }

        protected override object GetDefaultData()
        {
            return new { AccountScreenName = "" };
        }

        protected override string GetActionName()
        {
            return Resources.PrintAccountScreen;
        }

        protected override string GetActionKey()
        {
            return "PrintAccountScreen";
        }
    }
}
