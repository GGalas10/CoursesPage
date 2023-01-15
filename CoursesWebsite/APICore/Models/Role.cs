using System;

namespace APICore.Models
{
    public class Role : Entity
    {
        public string Name { get; protected set; }
        public Role(string name)
        {
            SetName(name);
        }        
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) 
                throw new Exception("Name cannot be empty");
            Name = name;
        }
    }
}
