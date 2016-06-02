using System;
using System.Linq;
using Zebo.Localization.Properties;

namespace Zebo.Modules.SettingsModule.BrowserViews
{
    class ZeboPosDocumentation : BrowserViewModel
    {
        public ZeboPosDocumentation()
        {
            Header = string.Format("ZeboPOS {0}", Resources.Documentation);
            Url = "http://www.zebopos.tk/en/content/zebopos-documentation";
        }
    }
}
