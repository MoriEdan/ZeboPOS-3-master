using System.Windows.Documents;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Services;

namespace Zebo.Modules.BasicReports.Reports.AccountReport
{
    class InternalAccountsViewModel : AccountReportViewModelBase
    {
        public InternalAccountsViewModel(IUserService userService, IApplicationState applicationState, ILogService logService, ISettingService settingService)
            : base(userService, applicationState, logService, settingService)
        {
        }

        protected override FlowDocument GetReport()
        {
            return CreateReport(Resources.InternalAccounts, null, true);
        }

        protected override string GetHeader()
        {
            return Resources.InternalAccounts;
        }
    }
}
