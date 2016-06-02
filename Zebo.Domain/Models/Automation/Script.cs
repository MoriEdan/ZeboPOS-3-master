using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Automation
{
    public class Script : EntityClass
    {
        public string HandlerName { get; set; }
        public string Code { get; set; }
    }
}
