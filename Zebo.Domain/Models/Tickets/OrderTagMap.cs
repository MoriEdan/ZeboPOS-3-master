using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Menus;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Tickets
{
    public class OrderTagMap : AbstractMap
    {
        public int OrderTagGroupId { get; set; }
        public string MenuItemGroupCode { get; set; }
        public int MenuItemId { get; set; }
    }
}
