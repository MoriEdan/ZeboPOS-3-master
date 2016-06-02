using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Zebo.Domain.Models.Menus;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Services.Common;

namespace Zebo.Modules.MenuModule
{
    [ModuleExport(typeof(MenuModule))]
    public class MenuModule : ModuleBase
    {
        [ImportingConstructor]
        public MenuModule()
        {
            AddDashboardCommand<EntityCollectionViewModelBase<MenuItemViewModel, MenuItem>>(Resources.ProductList, Resources.Products, 33);
            AddDashboardCommand<EntityCollectionViewModelBase<ScreenMenuViewModel, ScreenMenu>>(Resources.MenuList, Resources.Products, 33);
            AddDashboardCommand<PriceListViewModel>(Resources.BatchPriceList, Resources.Products, 33);
            AddDashboardCommand<MenuItemPriceDefinitionListViewModel>(Resources.PriceDefinitions, Resources.Products, 33);
            AddDashboardCommand<EntityCollectionViewModelBase<TaxTemplateViewModel, TaxTemplate>>(Resources.TaxTemplate.ToPlural(), Resources.Products, 33);
            AddDashboardCommand<EntityCollectionViewModelBase<ProductTimerViewModel, ProductTimer>>(Resources.ProductTimer.ToPlural(), Resources.Products, 33);
        }
    }
}
