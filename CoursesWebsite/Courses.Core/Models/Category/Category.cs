using Courses.Core.Models.Common;
using Courses.Core.Value_Object;

namespace Courses.Core.Models.Category
{
    public class Category : Entity
    {
        public Name Name { get; protected set; }
        private Category() { }
        public Category(Name name)
        {
            SetName(name);
        }
        public void SetName(Name name)
        {
            Name = name;
        }
    }
}
