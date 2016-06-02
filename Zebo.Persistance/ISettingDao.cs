using System.Collections.Generic;
using Zebo.Domain.Models.Settings;

namespace Zebo.Persistance
{
    public interface ISettingDao
    {
        string GetNextString(int numeratorId);
        int GetNextNumber(int numeratorId);
        IEnumerable<Terminal> GetTerminals();
    }
}
