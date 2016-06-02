using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Accounts;

namespace Zebo.Presentation.Services
{
    public interface IReportServiceClient
    {
        void PrintAccountScreen(AccountScreen accountScreen);
        void PrintAccountTransactions(Account account,string filter);
    }
}
