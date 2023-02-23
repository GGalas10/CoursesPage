using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Courses.Core.Value_Object
{
    [Owned]
    public record Password : IEquatable<Password>
    {
        
        [Required]
        [MinLength(8,ErrorMessage ="Hasło nie może być krótsze niż 8 znaków")]
        public string Value { get; set; }
        public Password()
        {
            Value = string.Empty;
        }
        public Password(string value)
        {
            Value = value;
        }
        public static implicit   operator string (Password value)
            => value.Value;
        public static implicit operator Password(string value)
            => new(value);
    }
}
