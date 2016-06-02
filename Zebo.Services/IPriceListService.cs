using System.Collections.Generic;
using Zebo.Domain.Models.Menus;
using Zebo.Persistance;
using Zebo.Persistance.Common;

namespace Zebo.Services
{
    public interface IPriceListService
    {
        void DeleteMenuItemPricesByPriceTag(string priceTag);
        void UpdatePriceTags(MenuItemPriceDefinition model);
        IEnumerable<string> GetTags();
        IEnumerable<PriceData> CreatePrices();
        void UpdatePrices(IList<PriceData> prices);
    }
}
