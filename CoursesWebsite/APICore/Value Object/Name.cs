using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Object_Value
{
    public class Name
    {
        public string Value { get; protected set; }

        public void SetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Value cannot be empty");
            Value= value.Trim();
        }
    }
}
