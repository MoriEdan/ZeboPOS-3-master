using System;
using System.Collections.Generic;
using Zebo.Domain.Models.Settings;

namespace Zebo.Presentation.Services
{
    public interface IWorkPeriodService 
    {
        bool StartWorkPeriod(string description);
        bool StopWorkPeriod(string description);
        IEnumerable<WorkPeriod> GetLastWorkPeriods(int count);
        DateTime GetWorkPeriodStartDate();
    }
}
