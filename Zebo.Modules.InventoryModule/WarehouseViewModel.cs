using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FluentValidation;
using Zebo.Domain.Models.Inventory;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class WarehouseViewModel : EntityViewModelBase<Warehouse>
    {
        private IEnumerable<WarehouseType> _warehouseTypes;
        public IEnumerable<WarehouseType> WarehouseTypes
        {
            get { return _warehouseTypes ?? (_warehouseTypes = Workspace.All<WarehouseType>()); }
        }

        private WarehouseType _warehouseType;
        public WarehouseType WarehouseType
        {
            get
            {
                return _warehouseType ?? (_warehouseType = WarehouseTypes.SingleOrDefault(x => x.Id == Model.WarehouseTypeId));
            }
            set
            {
                Model.WarehouseTypeId = value.Id;
                _warehouseType = null;
                RaisePropertyChanged(() => WarehouseType);
            }
        }

        protected override AbstractValidator<Warehouse> GetValidator()
        {
            return new WarehouseValidator();
        }

        public override Type GetViewType()
        {
            return typeof(WarehouseView);
        }

        public override string GetModelTypeString()
        {
            return Resources.Warehouse;
        }
    }

    internal class WarehouseValidator : EntityValidator<Warehouse>
    {
        public WarehouseValidator()
        {
            RuleFor(x => x.WarehouseTypeId).GreaterThan(0);
        }
    }
}
