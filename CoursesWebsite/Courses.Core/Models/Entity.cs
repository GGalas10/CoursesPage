using System;

namespace Courses.Core.Models
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public State State { get; protected set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            State = State.Active;
        }
        public void SetState(State state)
        {
            State = state;
        }
    }
}
