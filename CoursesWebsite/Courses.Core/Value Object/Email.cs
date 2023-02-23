using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Courses.Core.Value_Object
{
    [Owned]
    public record Email : IEquatable<Email>
    {
        public string Value { get; }
        public Email()
        {
            Value = string.Empty;
        }
        public Email(string value) 
        {
            if(string.IsNullOrEmpty(value)) 
                throw new ArgumentNullException("User email cannot be empty");
            var isValid = new EmailAddressAttribute().IsValid(value);
            if (isValid)
                throw new ArgumentException("Email structure is invalid");
            Value = value;
        }
        public static implicit operator Email(string value)
            => new(value);
        public static implicit operator string(Email emial) 
            => emial.Value;
    }
}
