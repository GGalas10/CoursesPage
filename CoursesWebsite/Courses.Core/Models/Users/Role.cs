using Courses.Core.Models.Commons;
using Courses.Core.Value_Object;

namespace Courses.Core.Models.Users
{
    public class Role : Entity
    {
        #region Properties
        public Name Name { get; protected set; }
        #endregion
        #region Constructors
        private Role() { }
        public Role(Name name) : base()
        {
            SetName(name);
        }
        #endregion
        #region Methods
        public void SetName(Name name)
        {
            Name = name;
        }
        #endregion
    }
}
