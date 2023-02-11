namespace Courses.Core.Value_Object
{
    public record Number
    {
        public int Value { get; set; }
        public Number(int value)
        {
            if (value < 0)
                throw new Exception("Number cannot be smaller than 0");
        }
        public static implicit operator Number(int value)
            => new(value);
        public static implicit operator int(Number value)
            => value.Value;
    }
}
