using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Value_Object
{
    public record Email
    {
        public string Value { get; }
        public Email(string value) 
        {
            if(string.IsNullOrEmpty(value)) 
                throw new ArgumentNullException("User email cannot be empty");
            var isValid = new EmailAddressAttribute().IsValid(value);
            if (isValid is false)
                throw new ArgumentException("Email structure is invalid");
            Value = value;
        }
        public static implicit operator Email(string value)
            => new(value);
        public static implicit operator string(Email emial) 
            => emial.Value;
    }
}
