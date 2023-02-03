using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Object_Value
{
    public record Name
    {
        public string Value { get; }

        public void SetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Value cannot be empty");
            Value= value.Trim();
        }
    }
}
