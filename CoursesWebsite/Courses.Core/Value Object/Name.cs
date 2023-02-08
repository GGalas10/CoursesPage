using Courses.Core.Value_Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Object_Value
{
    public record Name
    {
        public string Value { get; }
        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Both user name cannot be empty");
            Value = value;
        }
        public static implicit operator Name(string value)
            => new(value);
        public static implicit operator string(Name value)
            => value.Value;
    }
}
