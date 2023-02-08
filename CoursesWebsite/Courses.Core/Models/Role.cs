using APICore.Object_Value;
using System;

namespace Courses.Core.Models
{
    public class Role : Entity
    {
        #region Properties
        public Name Name { get; protected set; }
        #endregion
        #region Constructors
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
