using System;
using System.Linq;
using Zebo.Localization.Properties;

namespace Zebo.Modules.SettingsModule.BrowserViews
{
    class ZeboPosForum : BrowserViewModel
    {
        public ZeboPosForum()
        {
            Header = string.Format("ZeboPOS {0}", Resources.Forum);
            Url = "http://forum2.zebopos.tk";
        }
    }
}
