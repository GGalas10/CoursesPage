using System;

namespace APICore.Models
{
    public class Role : Entity
    {
        public string Name { get; protected set; }
        public State state { get; protected set; }
        public Role(string name) : base()
        {
            SetName(name);
            state = State.Active;
        }        
        public void SetName(string name)
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
