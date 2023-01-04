using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    internal class Lesson : Entity
    {
        public string LessonName { get; protected set; }
        public string LessonDescription { get; protected set; }
        //public byte[] Video { get;protected set; } check the best way to save Video file
    }
}
