using System;
using System.Linq;
using Zebo.Localization.Properties;

namespace Zebo.Modules.SettingsModule.BrowserViews
{
    class ZeboPosWiki : BrowserViewModel
    {
        public ZeboPosWiki()
        {
            Header = string.Format("ZeboPOS {0}", Resources.Wiki);
            Url = "http://www.zebopos.tk/wiki/";
        }
    }
}
