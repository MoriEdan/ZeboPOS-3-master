using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Accounts;
using Zebo.Domain.Models.Settings;

namespace Zebo.Services
{
    public interface IReportService
    {
        void PrintAccountScreen(AccountScreen accountScreen, WorkPeriod workperiod, Printer printer);
        void PrintAccountTransactions(Account account, WorkPeriod workPeriod, Printer printer, string filter);
    }
}
