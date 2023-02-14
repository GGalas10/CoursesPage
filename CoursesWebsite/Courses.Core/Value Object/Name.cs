namespace Courses.Core.Value_Object
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
        public static implicit operator string(Name name)
            => name.Value;
    }
}
