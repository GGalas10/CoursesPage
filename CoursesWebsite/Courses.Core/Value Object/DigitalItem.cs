using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Courses.Core.Value_Object
{
    [Owned]
    public record DigitalItem : IEquatable<DigitalItem>
    {
        public byte[] Value { get; }
        public DigitalItem() 
        { 
            Value = Array.Empty<byte>();
        }
        public DigitalItem(byte[] value)
        {
            if (value == null)
                throw new Exception("Value cannot be empty");
            Value = value;
        }
        public static implicit operator DigitalItem(byte[] item)
            => new(item);
        public static implicit operator byte[](DigitalItem item)
            => item.Value;
        public static async Task<byte[]> CreateFromIFromFile(IFormFile fromFile)
        {
           using(var memoryStream  = new MemoryStream())
            {
                await fromFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
