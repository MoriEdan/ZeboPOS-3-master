using System.ComponentModel.Composition;
using System.Linq;
using Zebo.Domain.Models.Inventory;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.Commands;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Services;

namespace Zebo.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class TransactionDocumentListViewModel : EntityCollectionViewModelBase<TransactionDocumentViewModel, InventoryTransactionDocument>
    {
        private readonly IApplicationState _applicationState;

        [ImportingConstructor]
        public TransactionDocumentListViewModel(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        protected override bool CanAddItem(object obj)
        {
            return _applicationState.CurrentWorkPeriod != null;
        }
    }
}
