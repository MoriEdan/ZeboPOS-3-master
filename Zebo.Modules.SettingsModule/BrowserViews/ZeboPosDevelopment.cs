using System;
using System.Linq;
using Zebo.Localization.Properties;

namespace Zebo.Modules.SettingsModule.BrowserViews
{
    class ZeboPosDevelopment : BrowserViewModel
    {
        public ZeboPosDevelopment()
        {
            Header = string.Format("ZeboPOS {0}", Resources.Development);
            Url = "https://github.com/emreeren/ZeboPOS-3";
        }
    }
}
