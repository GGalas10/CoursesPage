using APICore.Object_Value;
using System;

namespace Courses.Core.Models
{
    public class Role : Entity
    {
        public Name Name { get; protected set; }
        public State state { get; protected set; }
        public Role(Name name) : base()
        {
            SetName(name);
            state = State.Active;
        }        
        public void SetName(Name name)
        {
            if (string.IsNullOrEmpty(name)) 
                throw new Exception("Name cannot be empty");
            Name = name;
        }
        public void SetState(State newState)
        {
            state = newState;
        }
    }
}
