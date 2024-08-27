using Microsoft.EntityFrameworkCore;

namespace Courses.Core.Value_Object
{
    [Owned]
    public record Number : IEquatable<Number>
    {
        public int Value { get; }
        public Number()
        {

        }
        public Number(int value)
        {
            if (value < 0)
                throw new Exception("Number cannot be smaller than 0");
        }
        public static implicit operator Number(int value)
            => new Number(value);
        public static implicit operator int(Number value)
            => value.Value;
    }
}
