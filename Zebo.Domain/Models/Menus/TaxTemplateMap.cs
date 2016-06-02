﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Menus
{
    public class TaxTemplateMap : AbstractMap
    {
        public int TaxTemplateId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
    }
}
