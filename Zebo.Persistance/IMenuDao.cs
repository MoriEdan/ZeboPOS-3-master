using System.Collections.Generic;
using Zebo.Domain.Models.Menus;
using Zebo.Persistance.Common;

namespace Zebo.Persistance
{
    public interface IMenuDao
    {
        IEnumerable<ScreenMenu> GetScreenMenus();
        IEnumerable<string> GetMenuItemNames();
        IEnumerable<string> GetMenuItemGroupCodes();
        IEnumerable<string> GetMenuItemTags();
        IEnumerable<MenuItem> GetMenuItemsByGroupCode(string menuItemGroupCode);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<MenuItemData> GetMenuItemData();
        MenuItem GetMenuItemById(int id);
        IEnumerable<MenuItem> GetMenuItemsWithPortions();
    }
}
