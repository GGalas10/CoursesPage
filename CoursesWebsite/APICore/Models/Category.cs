using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    public class Category : Entity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public void SetName { get; protected set; }
    }
}
