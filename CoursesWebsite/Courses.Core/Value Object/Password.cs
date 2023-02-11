using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Value_Object
{
    public record Password
    {
        
        [Required]
        [MinLength(8,ErrorMessage ="Hasło nie może być krótsze niż 8 znaków")]
        public string Value { get; set; }
        public Password(string value)
        {
            Value = value;
        }
        public static implicit operator string (Password value)
            => value.Value;
        public static implicit operator Password(string value)
            => new(value);
    }
}
