using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
