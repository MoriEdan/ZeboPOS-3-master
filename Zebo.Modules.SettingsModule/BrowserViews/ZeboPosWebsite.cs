using System;
using System.Linq;
using Zebo.Localization.Properties;

namespace Zebo.Modules.SettingsModule.BrowserViews
{
    class ZeboPosWebsite : BrowserViewModel
    {
        public ZeboPosWebsite()
        {
            Header = string.Format("ZeboPOS {0}", Resources.Website);
            Url = "http://www.zebopos.tk";
        }
    }
}
