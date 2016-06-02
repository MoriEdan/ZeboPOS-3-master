using System.ComponentModel.Composition;
using Zebo.Domain.Models.Settings;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Services;

namespace Zebo.Modules.AutomationModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class TriggerListViewModel : EntityCollectionViewModelBase<TriggerViewModel, Trigger>
    {
        private readonly ITriggerService _triggerService;
        private readonly IMethodQueue _methodQueue;

        [ImportingConstructor]
        public TriggerListViewModel(ITriggerService triggerService, IMethodQueue methodQueue)
        {
            _triggerService = triggerService;
            _methodQueue = methodQueue;
        }

        protected override void OnDeleteItem(object obj)
        {
            base.OnDeleteItem(obj);
            _methodQueue.Queue("UpdateCronObjects", _triggerService.UpdateCronObjects);
        }
    }
}
