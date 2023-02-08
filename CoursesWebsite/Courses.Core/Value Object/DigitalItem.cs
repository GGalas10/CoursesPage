using APICore.Object_Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Value_Object
{
    public record DigitalItem
    {
        public byte[] Value;
        public DigitalItem(byte[] value)
        {
            if (value == null)
                throw new Exception("Digital item cannot be empty");
            Value = value;
        }
        public static implicit operator DigitalItem(byte[] item)
            => new(item);
        public static implicit operator byte[](DigitalItem item)
            => item.Value;
    }
}
