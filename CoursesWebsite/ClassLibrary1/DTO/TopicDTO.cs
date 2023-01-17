using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.DTO
{
    public class TopicDTO
    {
        public string Name { get; set; }
        public int Description { get; set; }
        public List<LessonDTO> lessons { get; set; }
    }
}
