using APICore.Object_Value;

namespace Courses.Core.Models
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
