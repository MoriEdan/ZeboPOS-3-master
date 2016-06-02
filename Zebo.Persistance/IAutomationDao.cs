using System.Collections.Generic;
using Zebo.Domain.Models.Automation;

namespace Zebo.Persistance
{
    public interface IAutomationDao
    {
        Dictionary<string, string> GetScripts();
        AppAction GetActionById(int appActionId);
        IEnumerable<string> GetAutomationCommandNames();
    }
}
