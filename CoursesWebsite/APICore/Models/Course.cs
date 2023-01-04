using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    internal class Course :Entity
    {
        private List<Topic> _topics;
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Author { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<Topic> Topics => _topics;
    }
}
