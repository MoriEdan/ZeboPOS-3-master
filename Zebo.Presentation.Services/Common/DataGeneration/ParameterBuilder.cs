using System.Collections.Generic;
using Zebo.Infrastructure.Helpers;

namespace Zebo.Presentation.Services.Common.DataGeneration
{
    internal class ParameterBuilder
    {
        private readonly IDictionary<string, string> _values = new Dictionary<string, string>();
        public ParameterBuilder Add(string key, string value)
        {
            _values.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            return JsonHelper.Serialize(_values);
        }
    }
}