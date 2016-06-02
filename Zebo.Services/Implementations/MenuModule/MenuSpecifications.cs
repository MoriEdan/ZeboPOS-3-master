using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Inventories;
using Zebo.Domain.Models.Menus;
using Zebo.Domain.Models.Tickets;
using Zebo.Persistance.Data.Specification;

namespace Zebo.Services.Implementations.MenuModule
{
    public static class MenuSpecifications
    {


        public static Specification<ScreenMenuItem> ScreenMenuItemsByMenuItemId(int menuItemId)
        {
            return new DirectSpecification<ScreenMenuItem>(x => x.MenuItemId == menuItemId);
        }

        public static Specification<Recipe> RecipesByMenuItemId(int menuItemId)
        {
            return new DirectSpecification<Recipe>(x => x.Portion.MenuItemId == menuItemId);
        }

        public static Specification<OrderTag> OrderTagsByMenuItemId(int menuItemId)
        {
            return new DirectSpecification<OrderTag>(x=>x.MenuItemId == menuItemId);
        }
    }
}
