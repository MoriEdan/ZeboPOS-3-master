using System.Collections.Generic;

namespace Zebo.Infrastructure.Data
{
    public interface IEntityCreator<out TModel>
    {
        IEnumerable<TModel> CreateItems(IEnumerable<string> data);
    }
}