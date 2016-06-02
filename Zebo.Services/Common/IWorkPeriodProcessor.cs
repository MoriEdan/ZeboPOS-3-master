using Zebo.Domain.Models.Settings;

namespace Zebo.Services.Common
{
    public interface IWorkPeriodProcessor
    {
        void ProcessWorkPeriodStart(WorkPeriod workPeriod);
        void ProcessWorkPeriodEnd(WorkPeriod workPeriod);
    }
}