﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Zebo.Domain.Models.Inventory;
using Zebo.Domain.Models.Menus;
using Zebo.Domain.Models.Tickets;
using Zebo.Infrastructure.Data;
using Zebo.Infrastructure.Data.Validation;
using Zebo.Localization.Properties;
using Zebo.Persistance.Common;
using Zebo.Persistance.Data;
using Zebo.Persistance.Specification;

namespace Zebo.Persistance.Implementations
{
    [Export(typeof(IMenuDao))]
    class MenuDao : IMenuDao
    {
        [ImportingConstructor]
        public MenuDao()
        {
            ValidatorRegistry.RegisterSaveValidator(new NonDuplicateSaveValidator<MenuItem>(string.Format(Resources.SaveErrorDuplicateItemName_f, Resources.MenuItem)));
            ValidatorRegistry.RegisterDeleteValidator(new MenuItemDeleteValidator());
            ValidatorRegistry.RegisterDeleteValidator(new ScreenMenuDeleteValidator());
        }

        public IEnumerable<ScreenMenu> GetScreenMenus()
        {
            return Dao.Query<ScreenMenu>();
        }

        public IEnumerable<string> GetMenuItemNames()
        {
            return Dao.Select<MenuItem, string>(x => x.Name, null).OrderBy(x=>x);
        }

        public IEnumerable<string> GetMenuItemGroupCodes()
        {
            return Dao.Distinct<MenuItem>(x => x.GroupCode);
        }

        public IEnumerable<string> GetMenuItemTags()
        {
            return Dao.Distinct<MenuItem>(x => x.Tag);
        }

        public IEnumerable<MenuItem> GetMenuItemsByGroupCode(string menuItemGroupCode)
        {
            return Dao.Query<MenuItem>(x => x.GroupCode == menuItemGroupCode);
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return Dao.Query<MenuItem>();
        }

        public IEnumerable<MenuItemData> GetMenuItemData()
        {
            return Dao.Select<MenuItem, MenuItemData>(
                    x => new MenuItemData { Id = x.Id, GroupCode = x.GroupCode, Name = x.Name }, x => x.Id > 0);
        }

        public MenuItem GetMenuItemById(int id)
        {
            return Dao.Single<MenuItem>(x => x.Id == id, x => x.Portions.Select(y => y.Prices));
        }

        public IEnumerable<MenuItem> GetMenuItemsWithPortions()
        {
            return Dao.Query<MenuItem>(x => x.Portions);
        }
    }

    public class MenuItemDeleteValidator : SpecificationValidator<MenuItem>
    {
        public override string GetErrorMessage(MenuItem model)
        {
            if (Dao.Exists<ScreenMenuItem>(x => x.MenuItemId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.MenuItem, Resources.Menu);
            if (Dao.Exists<Recipe>(x => x.Portion.MenuItemId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.MenuItem, Resources.Recipe);
            if (Dao.Exists<OrderTag>(x => x.MenuItemId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.MenuItem, Resources.OrderTag);
            return "";
        }
    }

    public class ScreenMenuDeleteValidator:SpecificationValidator<ScreenMenu>
    {
        public override string GetErrorMessage(ScreenMenu model)
        {
            if (Dao.Exists<TicketType>(x => x.ScreenMenuId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Menu, Resources.TicketType);
            if (Dao.Exists<Department>(x => x.ScreenMenuId == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Menu, Resources.Department);
            return "";
        }
    }
}
