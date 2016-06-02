using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Menus
{
    public class ProdcutTimerMap : AbstractMap
    {
        public int ProductTimerId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
    }
}
