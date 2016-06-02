using System.ComponentModel.Composition;
using Zebo.Domain.Models.Menus;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Services;

namespace Zebo.Modules.MenuModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class MenuItemPriceDefinitionListViewModel : EntityCollectionViewModelBase<MenuItemPriceDefinitionViewModel, MenuItemPriceDefinition>
    {
        private readonly IPriceListService _priceListService;

        [ImportingConstructor]
        public MenuItemPriceDefinitionListViewModel(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        protected override void BeforeDeleteItem(MenuItemPriceDefinition item)
        {
            _priceListService.DeleteMenuItemPricesByPriceTag(item.PriceTag);
        }
    }
}
