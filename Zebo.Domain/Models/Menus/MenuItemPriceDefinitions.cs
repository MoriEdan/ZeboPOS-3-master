using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Tickets;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Menus
{
    public class MenuItemPriceDefinition : EntityClass
    {
        [StringLength(10)]
        public string PriceTag { get; set; }
    }
}
