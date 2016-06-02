using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Zebo.Presentation.Common.Widgets;

namespace Zebo.Presentation.Common
{
    [ModuleExport(typeof(PresentationModule))]
    public class PresentationModule : ModuleBase
    {
        [ImportMany]
        public IEnumerable<IWidgetCreator> RegisteredCreators { get; set; }

        protected override void OnInitialization()
        {
            foreach (var registeredCreator in RegisteredCreators)
            {
                WidgetCreatorRegistry.RegisterWidgetCreator(registeredCreator);
            }
            base.OnInitialization();
        }
    }
}
