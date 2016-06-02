using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Zebo.Domain.Models.Settings;
using Zebo.Infrastructure.Cron;
using Zebo.Persistance.Data;
using Zebo.Presentation.Services.Common;
using Zebo.Services.Common;

namespace Zebo.Presentation.Services.Implementations.AutomationModule
{
    [Export(typeof(ITriggerService))]
    public class TriggerService : ITriggerService
    {
        private readonly List<CronObject> _cronObjects;
        private readonly IApplicationState _applicationState;

        [ImportingConstructor]
        public TriggerService(IApplicationState applicationState)
        {
            _applicationState = applicationState;
            _cronObjects = new List<CronObject>();
        }

        public void UpdateCronObjects()
        {
            CloseTriggers();

            var triggers = Dao.Query<Trigger>();
            foreach (var trigger in triggers)
            {
                var dataContext = new CronObjectDataContext(new List<CronSchedule> { CronSchedule.Parse(trigger.Expression) })
                    {
                        Object = trigger,
                        LastTrigger = trigger.LastTrigger
                    };

                var cronObject = new CronObject(dataContext);
                cronObject.OnCronTrigger += OnCronTrigger;
                _cronObjects.Add(cronObject);
            }
            _cronObjects.ForEach(x => x.Start());
        }

        public void CloseTriggers()
        {
            foreach (var cronObject in _cronObjects)
            {
                cronObject.Stop();
                cronObject.OnCronTrigger -= OnCronTrigger;
            }
            _cronObjects.Clear();
        }

        private void OnCronTrigger(object sender, CronEventArgs e)
        {
            using (var workspace = WorkspaceFactory.Create())
            {
                var trigger = workspace.Single<Trigger>(x => x.Id == ((Trigger)e.CronObject.Object).Id);
                if (trigger != null)
                {
                    trigger.LastTrigger = DateTime.Now;
                    workspace.CommitChanges();
                    if (_applicationState.ActiveAppScreen != AppScreens.Management)
                        _applicationState.NotifyEvent(RuleEventNames.TriggerExecuted, new { TriggerName = trigger.Name });
                }
                else e.CronObject.Stop();
            }
        }
    }
}
