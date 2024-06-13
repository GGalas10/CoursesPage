using Microsoft.EntityFrameworkCore;

namespace Courses.Core.Value_Object
{
    [Owned]
    public record Name : IEquatable<Name>
    {
        public string Value;
        public Name()
        {
            Value = string.Empty;
        }
        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Both user name cannot be empty");
            Value = value;
        }
        public static implicit operator Name(string value)
            => new(value);
        public static implicit operator string(Name name)
            => name.Value;
    }
}