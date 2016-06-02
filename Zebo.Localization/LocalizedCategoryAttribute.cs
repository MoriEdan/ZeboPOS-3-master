﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Zebo.Localization.Properties;

namespace Zebo.Localization
{
    public class LocalizedCategoryAttribute : CategoryAttribute
    {
        private readonly string _resourceName;
        public LocalizedCategoryAttribute(string resourceName)
            : base()
        {
            _resourceName = resourceName;
        }

        protected override string GetLocalizedString(string value)
        {
            return Resources.ResourceManager.GetString(_resourceName);
        }
    }
}
