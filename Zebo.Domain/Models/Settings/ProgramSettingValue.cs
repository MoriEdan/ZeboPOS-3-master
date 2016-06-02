using System.ComponentModel.DataAnnotations;
using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Settings
{
    public class ProgramSettingValue : EntityClass
    {
        [StringLength(250)]
        public string Value { get; set; }
    }
}
