using System.Collections.Generic;
using Zebo.Domain.Models.Settings;
using Zebo.Infrastructure.Data;

namespace Zebo.Persistance
{
    public interface IWorkPeriodDao
    {
        void StartWorkPeriod(string description,IWorkspace workspace);
        void StopWorkPeriod(string description, IWorkspace workspace);
        IEnumerable<WorkPeriod> GetLastWorkPeriods(int count);
    }
}
