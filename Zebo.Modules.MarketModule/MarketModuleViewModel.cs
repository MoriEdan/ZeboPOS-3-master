using System.Collections.Generic;
using System.ComponentModel.Composition;
using Zebo.Domain.Models.Menus;
using Zebo.Presentation.Common;
using Zebo.Services;

namespace Zebo.Modules.MarketModule
{
    [Export]
    public class MarketModuleViewModel : ObservableObject
    {
        private string _activeUrl;
        public string ActiveUrl
        {
            get { return _activeUrl; }
            set { _activeUrl = value; RaisePropertyChanged(() => ActiveUrl); }
        }
    }
}
