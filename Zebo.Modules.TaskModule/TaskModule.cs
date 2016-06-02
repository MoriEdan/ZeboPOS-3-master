using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Zebo.Domain.Models.Tasks;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Services.Common;

namespace Zebo.Modules.TaskModule
{
    [ModuleExport(typeof(TaskModule))]
    public class TaskModule : ModuleBase
    {
        [ImportingConstructor]
        public TaskModule()
        {
            AddDashboardCommand<EntityCollectionViewModelBase<TaskTypeViewModel, TaskType>>(Resources.TaskType.ToPlural(), Resources.Settings, 20);
        }
    }
}
