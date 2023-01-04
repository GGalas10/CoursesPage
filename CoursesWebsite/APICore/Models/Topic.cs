using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    internal class Topic: Entity
    {
        private List<Lesson> _lessons;
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<Lesson> Lessons => _lessons;
    }
}
