using System;
using System.ComponentModel.Composition;
using Zebo.Domain.Models.Inventory;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class WarehouseTypeViewModel : EntityViewModelBase<WarehouseType>
    {
        public override Type GetViewType()
        {
            return typeof(WarehouseTypeView);
        }

        public override string GetModelTypeString()
        {
            return Resources.WarehouseType;
        }
    }
}
