using System.ComponentModel.Composition;
using Zebo.Domain.Models.Accounts;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.AccountModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class PrintAccountTransactions : ActionType
    {
        private readonly IAccountService _accountService;
        private readonly IReportServiceClient _reportServiceClient;

        [ImportingConstructor]
        public PrintAccountTransactions(IAccountService accountService, IReportServiceClient reportServiceClient)
        {
            _accountService = accountService;
            _reportServiceClient = reportServiceClient;
        }

        public override void Process(ActionData actionData)
        {
            Account account = null;
            var accountId = actionData.GetAsInteger("AccountId");
            if (accountId > 0)
            {
                account = _accountService.GetAccountById(accountId);
            }

            if (account == null)
            {
                var accountName = actionData.GetAsString("AccountName");
                if (!string.IsNullOrEmpty(accountName))
                {
                    account = _accountService.GetAccountByName(accountName);
                }
            }

            if (account != null)
            {
                _reportServiceClient.PrintAccountTransactions(account, actionData.GetAsString("AccountTransactionsFilter"));
            }
        }

        protected override object GetDefaultData()
        {
            return new { AccountId = "", AccountName = "", AccountTransactionsFilter = "" };
        }

        protected override string GetActionName()
        {
            return Resources.PrintAccountTransactions;
        }

        protected override string GetActionKey()
        {
            return "PrintAccountTransactions";
        }
    }
}
