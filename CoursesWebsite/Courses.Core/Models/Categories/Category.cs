using Courses.Core.Models.Commons;
using Courses.Core.Value_Object;

namespace Courses.Core.Models.Categories
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
